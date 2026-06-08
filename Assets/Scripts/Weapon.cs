using System;
using UnityEngine;

namespace Lesson
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private int _level;
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected WeaponUpgradeData _upgradeData;

        protected float LastShootTime { get; set; }
        protected bool CanShoot { get; private set; }
        protected float Force { get; private set; }

        private float _shotDelay;

        protected virtual void Start()
        {
            if (_upgradeData.TryGetDataByLevel(_level, out WeaponData data) == false)
            {
                data = _upgradeData.GetDefaultData();
            }

            _shotDelay = data.ShotDelay;
            Force = data.Force;
        }

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

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
