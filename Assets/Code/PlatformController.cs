using UnityEngine;

namespace gamecodebase
{

}
public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;           
    [SerializeField] private float _leftBound = -8.5f;     
    [SerializeField] private float _rightBound = 8.5f;     

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");

       
        Vector3 movement = new Vector3(horizontalInput, 0, 0);
        _rigidbody.linearVelocity = movement * _speed;

        
        ClampPosition();
    }

    private void ClampPosition()
    {
        Vector3 currentPosition = transform.position;

       
        currentPosition.x = Mathf.Clamp(currentPosition.x, _leftBound, _rightBound);

        transform.position = currentPosition;
    }
}