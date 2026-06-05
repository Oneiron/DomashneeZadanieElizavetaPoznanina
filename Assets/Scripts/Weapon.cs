using UnityEngine;

namespace Lesson
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected int _countInClip;
        [SerializeField] protected float _force;
        [SerializeField] private float _shotDelay;

        protected bool CanShoot { get; private set; }
        public float LastShootTime { get; protected set; }

        private void Update()
        {
            CanShoot = _shotDelay <= LastShootTime;

            if (CanShoot)
            {
                return;
            }

            LastShootTime += Time.deltaTime;
        }

        public abstract void Fire();
        public abstract void Recharge();

        public virtual void GetInfo()
        {
            Debug.LogError(_shotDelay);
        }
    }
}
