using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectPunchable : MonoBehaviour
{
    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Punch(Transform pushDirection, float pushForce)
    {
        Vector3 pushVector = pushDirection.transform.forward;
        var AdjForce = pushForce * (_rb.mass / 2f);
        _rb.AddForce(pushVector * AdjForce, ForceMode.Impulse);
    }
}
