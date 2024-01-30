using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class BeakableBehaviour : MonoBehaviour
{
    public bool Broken = false;
    public float Strength = 1f;
    public float Mass = 10f;
    public int Value = 0;
    private Collider _coll;
    private Rigidbody _rb;
    public GameObject BrokenVersion; 

    private void Awake()
    {
        _coll = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _rb.mass = Mass;
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.impulse.sqrMagnitude > Strength) Break();
    }

    private void Break()
    {
        if (Broken) return;
        Broken = true;
        if (BrokenVersion != null)
        {
            Instantiate(BrokenVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
