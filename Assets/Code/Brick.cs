using UnityEngine;

namespace gamecodebase
{

}

public class Brick : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private int _maxHealth = 3; 

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        UpdateColor();  
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }

    public void TakeDamage()
    {
        _currentHealth--;

        Debug.Log("Кирпичу осталось хп: " + _currentHealth);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);  
        }
        else
        {
            UpdateColor();  
        }
    }

    private void UpdateColor()
    {
        float healthPercent = (float)_currentHealth / _maxHealth;
        Color currentColor = _renderer.material.color;
        currentColor *= healthPercent; 

        _renderer.material.color = currentColor;
    }
}