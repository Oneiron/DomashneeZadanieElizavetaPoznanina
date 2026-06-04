using System;
using UnityEngine;

namespace Lesson
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage = 1.0f;
        [SerializeField] private float _force = 3.0f;

        public bool IsActive { get; private set; }

        private Rigidbody _rigidbody;

        public float Force
        {
            get
            {
                if (_force <= 0)
                {
                    return 0;
                }

                return _force;
            }

            set
            {
                if (IsActive == false)
                {
                    _force = 0;
                    return;
                }

                _force = value;
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnBecameInvisible()
        {
            if (IsActive == false)
            {
                return;
            }

            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);

            if (other.collider.TryGetComponent<HealthController>(out HealthController health))
            {
                if (health.CanTakeDamage(_damage))
                {
                    return;
                }

                if (other.collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody) == false)
                {
                    rigidbody = other.gameObject.AddComponent<Rigidbody>();
                }

                rigidbody.AddForce(_rigidbody.linearVelocity * Force, ForceMode.Impulse);
            }
        }

        public void Sleep()
        {
            _rigidbody.Sleep();
            gameObject.SetActive(false);
            IsActive = false;
        }

        public void Run(Vector3 path, Vector3 position)
        {
            transform.position = position;
            transform.parent = null;
            gameObject.SetActive(true);
            _rigidbody.WakeUp();
            _rigidbody.AddForce(path);
            IsActive = true;
        }
    }
}
