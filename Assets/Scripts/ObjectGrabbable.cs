using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody _rb;
    private Transform _destination = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void Grab(Transform destination)
    {
        _destination = destination;
        _rb.useGravity = false;
        _rb.drag = 5f;
    }
    public void Drop()
    {
        _destination = null;
        _rb.useGravity = true;
        _rb.drag = 0f;
    }

    public void Push(Transform pushDirection, float pushForce)
    {
        Vector3 pushVector = pushDirection.transform.forward;
        _rb.AddForce(pushVector * pushForce, ForceMode.Impulse);
    }
    private void FixedUpdate()
    {
        if (_destination != null)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, _destination.position, Time.deltaTime * 10f);
            _rb.MovePosition(newPos);
        }
    }
}