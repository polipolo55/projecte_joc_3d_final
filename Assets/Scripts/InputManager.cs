using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    public Vector2 rotation, movement;
    public UnityEvent jumped, objectPickup, attack;

    public void OnRotate(InputAction.CallbackContext ctx)
    {
        rotation = ctx.ReadValue<Vector2>();
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started) jumped.Invoke();
    }
    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.started) attack.Invoke();
    }
    public void OnPickup(InputAction.CallbackContext ctx)
    {
        if (ctx.started) objectPickup.Invoke();
    }
}
