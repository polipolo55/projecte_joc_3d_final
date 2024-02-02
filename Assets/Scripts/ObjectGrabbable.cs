using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody _rb;
    private Transform _destination = null;
    private Collider _collider;
    public bool special = false;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
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
        _collider.enabled = true;
        transform.SetParent(null);
    }

    public void GrabSpecial(Transform destination)
    {
        transform.localPosition = new Vector3(0.2f, -0.25f, -0.1f);
        transform.rotation = Quaternion.Euler(-170, -306, 90);
        transform.SetParent(destination, false);
        _rb.useGravity = false;
        _rb.drag = 5f;
        _collider.enabled = false;
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
            if(!special)
            {
                Vector3 newPos = Vector3.Lerp(transform.position, _destination.position, Time.deltaTime * 10f);
                _rb.MovePosition(newPos);
            }

        }
    }
}