using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class BeakableBehaviour : MonoBehaviour
{
    [Header("Object Properties")]
    public bool Broken = false;
    public float Strength = 1f;
    public float Health = 1f;

    [Space]
    [Header("Physics Properties")]
    public float Mass = 10f;
    public bool isKinematic = false;

    [Space]
    [Header("Gameplay Properties")]
    [Min(0)]
    public int Value = 0;


    [Space]
    public bool WillDissapear = false;
    public GameObject ParticleSystem;

    [Range(0.05f, 1f)]
    public float DissapearTime = 0.5f;

    private Collider _coll;
    private Rigidbody _rb;
    private ObjectGrabbable _grab;
    public GameObject BrokenVersion;
    public AudioClip BreakSound;
    private AudioSource _audioSource;
    public static event Action<BeakableBehaviour> OnObjectBroken = delegate { };

    private void Awake()
    {
        _coll = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _grab = GetComponent<ObjectGrabbable>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.dopplerLevel = 4f;
        _rb.mass = Mass;      
        _rb.isKinematic = isKinematic;
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

    public void SubtractHealth(float amount)
    {
        Health -= amount;
    }

    private void Break()
    {
        if (Broken) return;
        if (_grab != null)
        {
            _grab.Drop();
            Destroy(_grab);
        }
        Broken = true;
        _audioSource.PlayOneShot(BreakSound);
        OnObjectBroken.Invoke(this);
        if (BrokenVersion != null)
        {
            GameObject brokenObject = Instantiate(BrokenVersion, transform.position, transform.rotation);

            Rigidbody[] brokenRbs = brokenObject.GetComponentsInChildren<Rigidbody>();

            var nRigid = brokenRbs.Length;

            foreach (Rigidbody rb in brokenRbs)
            {
                rb.velocity = _rb.velocity;
                rb.angularVelocity = _rb.angularVelocity;
                rb.mass = Mass / nRigid;
                GameManager.instance.PoolingManager.AddPiece(rb.gameObject);
            }

            Destroy(gameObject);
        } else if (_rb != null && _rb.isKinematic == true) { 
            _rb.isKinematic = false;
        } else if (WillDissapear == true) {
            var ps = Instantiate(ParticleSystem, transform.position, Quaternion.identity);
            ps.GetComponent<ParticleSystem>().Play();
            ps.transform.SetParent(transform);
            Destroy(gameObject, DissapearTime);  
        }
    }
}
