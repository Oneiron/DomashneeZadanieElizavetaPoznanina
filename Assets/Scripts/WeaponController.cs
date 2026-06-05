using UnityEngine;

namespace Lesson
{
    public sealed class WeaponController : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _weapon.Fire();
            }

            if (Input.GetMouseButton(1))
            {
                _weapon.Recharge();
            }
        }
    }
}
