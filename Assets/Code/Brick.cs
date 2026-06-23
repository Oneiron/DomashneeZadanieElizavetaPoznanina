using UnityEngine;

namespace gamecodebase
{

}

public class Brick : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }
}