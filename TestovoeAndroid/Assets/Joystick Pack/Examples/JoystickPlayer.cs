using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    public VariableJoystick _joystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 move = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical) * _moveSpeed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }
}