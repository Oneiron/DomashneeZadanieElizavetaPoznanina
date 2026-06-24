using UnityEngine;
using UnityEngine.SceneManagement;
namespace gamecodebase
{

}

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _platform;

    [SerializeField] private float _startSpeed = 8f;
    [SerializeField] private float _bounceForce = 10f;
    [SerializeField] private float _deathY = -3f;

    private bool _isStuckToPlatform = true;

    private void Update()
    {
        if (_isStuckToPlatform)
        {
            FollowPlatform();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Launch();
            }
        }
        else
        {
            CheckDeath();
        }
    }

    private void FollowPlatform()
    {
        Vector3 pos = _platform.position;
        pos.y += 0.6f;
        transform.position = pos;

        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.useGravity = false;
    }

    private void Launch()
    {
        _isStuckToPlatform = false;
        _rigidbody.useGravity = true;

        float randomX = Random.Range(-0.5f, 0.5f);
        Vector3 direction = new Vector3(randomX, 1, 0).normalized;

        _rigidbody.linearVelocity = direction * _startSpeed;
    }

    private void CheckDeath()
    {
        if (transform.position.y < _deathY)
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        string Level1 = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(Level1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Brick>(out var brick))
        {
            brick.TakeDamage();
        }

        Vector3 velocity = _rigidbody.linearVelocity;

        if (velocity.y < 0 || Mathf.Abs(velocity.y) < 2f)
        {
            velocity.y = _bounceForce;
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            float hitOffset = transform.position.x - collision.transform.position.x;
            velocity.x = hitOffset * 3f;
            velocity.y = Mathf.Max(velocity.y, _bounceForce);
        }

        _rigidbody.linearVelocity = velocity;
    }
}