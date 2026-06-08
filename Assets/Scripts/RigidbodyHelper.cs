using UnityEngine;

namespace Lesson
{
    public static class RigidbodyHelper
    {
        public static Rigidbody AddOrGetRigidbody(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out Rigidbody rigidbody) == false)
            {
                rigidbody = gameObject.AddComponent<Rigidbody>();
            }

            return rigidbody;
        }

        public static Rigidbody GetOrAddRigidbody(this GameObject gameObject)
        {
            return AddOrGetRigidbody(gameObject);
        }

        public static void PrintName(this MyClass myClass, int number)
        {
            Debug.LogError($"MyClass: {myClass}, number: {number}");
        }
    }

    public sealed class MyClass
    {
        public static int Test;
    }
}
