using UnityEngine;

namespace Lesson
{
    public abstract class A
    {
        // public A(int t)
        // {
        //    
        // }

        public virtual void PrintName()
        {
            Debug.LogError(nameof(A));
        }
    }

    public sealed class B : A
    {
        // public B(int t) : base(t)
        // {
        //    
        // }
        //
        // public B() : this(42)
        // {
        //    
        // }

        public new void PrintName()
        {
            Debug.LogError(nameof(B));
        }
    }

    // class C : B
    // {
    //    
    // }

    public class ExampleMonoBehaviour : MonoBehaviour
    {
        public ExampleMonoBehaviour() // dont override constructors in MonoBehaviour
        {

        }
    }
}
