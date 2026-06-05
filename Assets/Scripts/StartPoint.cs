using UnityEngine;

namespace Lesson
{
    public class StartPoint : MonoBehaviour
    {
        private void Start()
        {
            // A a = new A();
            // a.PrintName();
            A ab = new B();
            ab.PrintName();
            B b = new B();
            b.PrintName();

            // B ba = new A();
        }
    }
}
