using UnityEngine;

namespace Lesson
{
    public sealed class Gun : Weapon
    {
        [SerializeField] private Bullet _bulletPrefab;

        private Transform _bulletRoot;
        private Bullet[] _bullets;

        private void Start()
        {
            _bulletRoot = new GameObject("Bullet root").transform;
            Recharge();
        }

        public override void Fire()
        {
            if (CanShoot == false)
            {
                return;
            }

            if (TryGetBullet(out Bullet bullet))
            {
                bullet.Run(_barrel.forward * _force, _barrel.position);
                LastShootTime = 0.0f;
            }
        }

        public override void Recharge()
        {
            if (IsAnyActiveBullet())
            {
                return;
            }

            _bullets = new Bullet[_countInClip];
            for (int i = 0; i < _countInClip; i++)
            {
                Bullet bullet = Instantiate(_bulletPrefab, _bulletRoot);
                bullet.Sleep();
                _bullets[i] = bullet;
            }
        }

        private bool IsAnyActiveBullet()
        {
            if (_bullets == null)
            {
                return false;
            }

            for (int i = 0; i < _countInClip; i++)
            {
                Bullet bullet = _bullets[i];

                if (bullet == null)
                {
                    continue;
                }

                if (bullet.IsActive)
                {
                    return false;
                }
            }

            return true;
        }

        private bool TryGetBullet(out Bullet result)
        {
            int candidate = -1;
            result = default;

            if (_bullets == null)
            {
                return false;
            }

            for (int i = 0; i < _bullets.Length; i++)
            {
                Bullet bullet = _bullets[i];
                if (bullet == null)
                {
                    continue;
                }

                if (bullet.IsActive)
                {
                    continue;
                }

                candidate = i;
                break;
            }

            if (candidate == -1)
            {
                return false;
            }

            result = _bullets[candidate];
            return true;
        }

        public override void GetInfo()
        {
            base.GetInfo();

            Debug.LogError(_countInClip);
        }
    }
}
