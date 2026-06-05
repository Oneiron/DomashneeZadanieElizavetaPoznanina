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
        private Color[] _colors = new Color[3] { Color.red, Color.green, Color.blue };

        public float MaxHp
        {
            get
            {
                return _maxHp;
            }
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

        public bool CanAddHealth(int health)
        {
            if (_isAlive == false)
            {
                return false;
            }

            if (_health >= _maxHp)
            {
                return false;
            }

            _health += health;
            return true;
        }

        private IEnumerator Die()
        {
            var component = GetComponent<Renderer>();

            int counter = 10;
            do
            {
                component.material.color = _colors[Random.Range(0, _colors.Length)];
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                component.material.color = _colors[Random.Range(0, _colors.Length)];
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                component.material.color = _colors[Random.Range(0, _colors.Length)];
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                counter--;
            }
            while (counter >= 0);

            yield return new WaitForSeconds(_lifeTime);

            StartCoroutine(Fade());
        }

        private IEnumerator Fade()
        {
            // if (TryGetComponent(out Renderer renderer))
            // {
            //     Color color = renderer.material.color;
            //     for (float alpha = 1.0f; alpha >= 0; alpha -= 0.1f)
            //     {
            //         color.a = alpha;
            //         renderer.material.color = color;
            //         yield return new WaitForSeconds(0.1f);
            //     }
            // }

            if (TryGetComponent(out Collider collider))
            {
                collider.enabled = false;
                yield return new WaitForSeconds(5.1f);
            }

            Destroy(gameObject);
        }
    }
}
