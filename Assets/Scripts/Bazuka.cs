using System.Net.Sockets;
using UnityEngine;

namespace Lesson
{
    public sealed class Bazuka : Weapon
    {
        [SerializeField] private Rocket _rocketPrefab;

        private Rocket _instantiateRocket;

        private void Start()
        {
            Recharge();
        }

        public override void Fire()
        {
            if (_instantiateRocket)
            {
                _instantiateRocket.Run(_barrel.forward * _force);
                _instantiateRocket = null;
            }
        }

        public override void Recharge()
        {
            if (_instantiateRocket != null)
            {
                return;
            }
            _instantiateRocket = Instantiate(_rocketPrefab, _barrel);
            _instantiateRocket.Sleep(_barrel.position);
        }
    }
}
