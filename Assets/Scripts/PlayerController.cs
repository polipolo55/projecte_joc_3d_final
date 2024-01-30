using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovementBehaviour))]
[RequireComponent(typeof(InputManager))]

public class PlayerController : MonoBehaviour
{
    IMovementBehaviour _mb;
    InputManager _input;

    private void Awake()
    {
        _input = GetComponent<InputManager>();
        _mb = GetComponent<IMovementBehaviour>();
    }
    public void OnJump()
    {
        _mb.Jump();
    }

    private void FixedUpdate()
    {
        if (_input.rotation != Vector2.zero)
        {
            _mb.Rotate(_input.rotation);
        }
        if(_input.movement != Vector2.zero)
        {
            var dir = transform.forward * _input.movement.y + transform.right * _input.movement.x;
            _mb.Move(dir);
        }
    }
}
