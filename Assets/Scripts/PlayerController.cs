using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovementBehaviour))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(PickupBehaviour))]

public class PlayerController : MonoBehaviour
{
    IMovementBehaviour _mb;
    PickupBehaviour _pb;
    PunchBehaviour _punchB;
    InputManager _input;

    public Animator animator;

    private void Awake()
    {
        _pb = GetComponent<PickupBehaviour>();
        _punchB = GetComponent<PunchBehaviour>();
        _input = GetComponent<InputManager>();
        _mb = GetComponent<IMovementBehaviour>();
        GameManager.instance.Player = gameObject;
    }
    public void OnJump()
    {
        _mb.Jump();
    }
    public void OnGrab()
    {
        _pb.Grab(false);
    }
    public void OnClickGrab()
    {
        if (_pb.HoldingObject()) _pb.Grab(true);
        else
        {
            _punchB.Punch();
        }
    }

    private void Update()
    {
        animator.SetBool("Punching", _input.attacking);
    }

    private void FixedUpdate()
    {
        if (_input.rotation != Vector2.zero)
        {
            _mb.Rotate(_input.rotation);
        }
        if (_input.movement != Vector2.zero)
        {
            var dir = transform.forward * _input.movement.y + transform.right * _input.movement.x;
            _mb.Move(dir);
        }
    }
}
