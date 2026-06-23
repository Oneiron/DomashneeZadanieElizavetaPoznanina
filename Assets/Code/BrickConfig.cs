using UnityEngine;

[CreateAssetMenu(fileName = "BrickConfig", menuName = "Game/Brick Config")]
public class BrickConfig : ScriptableObject
{
    [SerializeField] private Color[] _rowColors;

    public Color GetColor(int rowIndex)
    {
        // Если рядов больше, чем цветов — повторяем цвета
        int index = rowIndex % _rowColors.Length;
        return _rowColors[index];
    }

    public int ColorCount => _rowColors.Length;
}