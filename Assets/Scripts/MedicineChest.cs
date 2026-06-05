using UnityEngine;

namespace Lesson
{
    public sealed class MedicineChest : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HealthController healthController))
            {
                if (healthController.CanAddHealth(1))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
