using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove
{
    [Header("Components")]
    [SerializeField] private Rigidbody _rb;

    [Header("Parameters")]
    [SerializeField] private float _speed = 5f;

    [Header("Animations")]
    [SerializeField] private PlayerAnimations _animations;

    private Vector2 _movement;

    public void Move(Vector2 movement)
    {
        _movement = movement;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_movement.x * _speed, _rb.velocity.y, _movement.y * _speed);
        _rb.position = new Vector3(_rb.position.x, _rb.position.y, _rb.position.z);

        if( _animations != null)
        _animations.Move(_movement.sqrMagnitude);

        // Rotate the player to the direction of _movement
        if (_movement != Vector2.zero)
        {
            _rb.rotation = Quaternion.LookRotation(new Vector3(_movement.x, 0f, _movement.y));
        }
    }
    public void Initialize( Rigidbody rb)
    {

        _rb = rb;
    }
}
