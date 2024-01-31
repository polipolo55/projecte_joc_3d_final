using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class BeakableBehaviour : MonoBehaviour
{
    public bool Broken = false;
    public float Strength = 1f;
    public float Health = 1f;
    public float Mass = 10f;
    public int Value = 0;
    private Collider _coll;
    private Rigidbody _rb;
    public GameObject BrokenVersion;
    public static event Action<BeakableBehaviour> OnObjectBroken = delegate { };

    private void Awake()
    {
        _coll = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _rb.mass = Mass;      
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.impulse.sqrMagnitude > Strength && !Broken) Break();
        else if (!Broken)
        {
            Health -= collision.impulse.sqrMagnitude;
            if (Health <= 0) Break();
        }
    }

    private void Break()
    {
        if (Broken) return;
        Broken = true;
        OnObjectBroken.Invoke(this);
        if (BrokenVersion != null)
        {
            Instantiate(BrokenVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        } else if (_rb != null && _rb.isKinematic == true) { 
            _rb.isKinematic = false;
        }
    }
}
