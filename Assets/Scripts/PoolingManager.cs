using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public int poolSize = 10;
    public int currentPoolSize = 0;
    private List<GameObject> _pool = new List<GameObject>();

    private void Awake()
    {
        GameManager.instance.PoolingManager = this;
    }

    public void AddPiece(GameObject piece)
    {
        currentPoolSize = _pool.Count;
        _pool.Add(piece);

        if (_pool.Count > poolSize)
        {
            DeactivatePiece(_pool[0]);
            _pool.RemoveAt(0);
        }
    }

    public void DeactivatePiece(GameObject piece)
    {
        var _rb = piece.GetComponent<Rigidbody>();
        if (_rb != null)
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _rb.isKinematic = true;
        }
        var _collider = piece.GetComponent<Collider>();
        if (_collider != null)
        {
            _collider.enabled = false;
        }
    }   
}
