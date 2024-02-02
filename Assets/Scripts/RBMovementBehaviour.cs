using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class RBMovementBehaviour : MonoBehaviour, IMovementBehaviour
{
    public Rigidbody _rb;
    public Transform _camerarotation;
    public LayerMask ground;

    [Header("Movement")]
    public float _speed = 5f;
    public float _groundDrag = 10f;
    public float _jumpForce = 5f;
    public float _jumpCooldown = 1f;
    public float _airMultiplier = 2f;

    private Vector3 _dir = Vector3.forward;
    private bool grounded = false;
    private bool canJump = true;
    private float playerHeight = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        playerHeight = transform.lossyScale.y * 2f;
    }
    public void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        if (grounded) _rb.drag = _groundDrag;
        else _rb.drag = 0;
        SpeedCap();
    }

    public void Rotate(Vector2 rotation)
    {
        _rb.rotation = Quaternion.Euler(0, _camerarotation.eulerAngles.y, 0);
    }

    public void Move()
    {
        _rb.AddForce(new Vector3(_dir.x * _speed * 10f, 0, _dir.z * _speed * 10f), ForceMode.Force);
    }

    public void Move(Vector3 dir)
    {
        SetDir(dir);
        Move();
    }

    public void Move(Vector3 dir, float speed)
    {
        SetDir(dir);
        SetSpeed(speed);
        Move();
    }
    public void Jump()
    {
        if (grounded && canJump)
        {
            canJump = false;
            _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
            _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
            Invoke(nameof(JumpReset), _jumpCooldown);
        }
    }

    public void SetDir(Vector3 dir)
    {
        _dir = dir;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SpeedCap()
    {
        Vector3 totalVelocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        if (totalVelocity.magnitude > _speed)
        {
            Vector3 limitedVelocity = totalVelocity.normalized * _speed;
            _rb.velocity = new Vector3(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
        }
    }

    public void JumpReset()
    {
        canJump = true;
    }

    public void MoveToPoint(Vector3 target)
    {
        throw new System.NotImplementedException();
    }

    public void MoveToPoint(Vector3 target, float speed)
    {
        throw new System.NotImplementedException();
    }
}
