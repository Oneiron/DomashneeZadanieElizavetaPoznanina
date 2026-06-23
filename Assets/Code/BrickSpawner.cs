using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private Brick _brickPrefab;        

    [Header("Grid Settings")]
    [SerializeField] private int _columns = 8;          
    [SerializeField] private int _rows = 5;             
    [SerializeField] private float _spacingX = 1.5f;  
    [SerializeField] private float _spacingY = 0.8f;   
    [SerializeField] private Vector3 _startPosition = new Vector3(-5f, 5f, 0f); 

    [Header("Config")]
    [SerializeField] private BrickConfig _config;      

    private void Start()
    {
        SpawnBricks();
    }

    private void SpawnBricks()
    {
        for (int row = 0; row < _rows; row++)       
        {
          
            Color rowColor = _config.GetColor(row);

            for (int col = 0; col < _columns; col++)   
            {
             
                float x = _startPosition.x + col * _spacingX;
                float y = _startPosition.y - row * _spacingY;
                Vector3 position = new Vector3(x, y, 0);

           
                Brick newBrick = Instantiate(_brickPrefab, position, Quaternion.identity);

              
                newBrick.SetColor(rowColor);
            }
        }
    }
}