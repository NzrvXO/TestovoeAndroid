using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rb;

    [Inject]
    private void Construct(FloatingJoystick floatingJoystick)
    {
        _joystick = floatingJoystick;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        Quaternion rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        Vector3 move = rotation * moveDirection * _moveSpeed;

        _rb.velocity = new Vector3(move.x, _rb.velocity.y, move.z);
    }
}
