using System;
using UnityEngine;

namespace Lesson
{
    [CreateAssetMenu(fileName = "ExampleScriptableObject", menuName = "Data/ExampleScriptableObject")]
    public sealed class ExampleScriptableObject : ScriptableObject
    {
        [Serializable]
        private sealed class Test
        {
            public int Id;
            public string Name;
        }

        [SerializeField] private Test _test;

        public int Health;
        public GameObject Prefab;
    }
}
