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

        if (_rb != null)
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
        }
        transform.SetParent(destination, false);
        _rb.useGravity = false;
        _rb.drag = 5f;
        _collider.enabled = false;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = Vector3.zero;
        transform.localPosition = new Vector3(0.13f, -0.1f, -0.2f);
        transform.localRotation = Quaternion.Euler(-47, -122, -104);
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