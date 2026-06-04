using System.Collections;
using UnityEngine;

namespace Lesson
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private float _health = 3.0f;
        [SerializeField] private float _lifeTime = 5.0f;

        private float _maxHp;
        private bool _isAlive = true;

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

            if (_health >= _maxHp)
            {
                return false;
            }

            float health = _health + _maxHp * 0.25f;

            _health = Mathf.Min(health, _maxHp);

            return true;
        }

        private IEnumerator Die()
        {
            var component = GetComponent<Renderer>();

            component.material.color = Color.red;
            yield return new WaitForSeconds(1.0f);
            component.material.color = Color.green;
            yield return new WaitForSeconds(1.0f);
            component.material.color = Color.red;
            yield return new WaitForSeconds(1.0f);
            component.material.color = Color.magenta;

            yield return new WaitForSeconds(_lifeTime);

            StartCoroutine(Fade());
        }

        private IEnumerator Fade()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                Color color = renderer.material.color;
                for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f)
                {
                    color.a = alpha;
                    renderer.material.color = color;
                    yield return new WaitForSeconds(0.01f);
                }
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