using System.Collections;
using UnityEngine;

namespace Lesson
{
    public sealed class HealthController : MonoBehaviour
    {
        [SerializeField] private float _health = 3.0f;
        [SerializeField] private float _lifeTime = 5.0f;

        private bool _isAlive = true;
        private float _maxHp;
        private Color[] _colors = { Color.red, Color.green, Color.blue, Color.magenta };
        private Vector2 _randomColorChangeTime = new(0.04f, 0.9f);

        public float MaxHp
        {
            get { return _maxHp; }
        }

        private void Start()
        {
            _maxHp = _health;
        }

        public bool CanTakeDamage(float damage)
        {
            if (_isAlive == false)
            {
                return false;
            }

            _health -= damage;

            if (_health <= 0)
            {
                StartCoroutine(Die());
                _isAlive = false;
                return false;
            }

            return true;
        }

        public bool CanAddHealth()
        {
            if (_isAlive == false)
            {
                return false;
            }

            if (_health >= MaxHp)
            {
                return false;
            }

            float health = _health + MaxHp * 0.25f;

            _health = Mathf.Min(health, MaxHp);

            return true;
        }

        private IEnumerator Die()
        {
            var renderer = GetComponent<Renderer>();

            int counter = 10;
            do
            {
                renderer.material.color = _colors[Random.Range(0, _colors.Length)];
                yield return new WaitForSeconds(Random.Range(_randomColorChangeTime.x, _randomColorChangeTime.y));
                renderer.material.color = _colors[Random.Range(0, _colors.Length)];
                yield return new WaitForSeconds(Random.Range(_randomColorChangeTime.x, _randomColorChangeTime.y));
                renderer.material.color = _colors[Random.Range(0, _colors.Length)];
                yield return new WaitForSeconds(Random.Range(_randomColorChangeTime.x, _randomColorChangeTime.y));
                counter--;
            }
            while (counter >= 0);

            yield return new WaitForSeconds(_lifeTime);

            StartCoroutine(Fade(renderer));
        }

        private IEnumerator Fade(Renderer renderer)
        {
            Color color = renderer.material.color;
            for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f)
            {
                color.a = alpha;
                renderer.material.color = color;
                yield return new WaitForSeconds(0.1f);
            }

            if (TryGetComponent(out Collider collider))
            {
                Destroy(collider);
            }

            yield return new WaitForSeconds(5.0f);

            Destroy(gameObject);
        }
    }
}
