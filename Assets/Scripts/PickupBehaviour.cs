using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupBehaviour : MonoBehaviour
{
    public float _pickupRange = 2f;
    public bool _isPickup = false;
    public bool _pickedUp = false;

    public Transform headPos;
    public RawImage crosshair;
    private void Update()
    {
        if(_isPickup) crosshair.color = Color.red;
        else crosshair.color = Color.white;
        if (Physics.Raycast(headPos.transform.position, headPos.transform.forward, out RaycastHit hitInfo, _pickupRange)) 
        {
            if(hitInfo.transform.TryGetComponent(out ObjectGrabbable objectGrabbable))
            {
                _isPickup = true;
            }
            else _isPickup = false;
        } 
        else _isPickup=false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(headPos.transform.position, headPos.transform.forward * _pickupRange);
    }

    public void Grab()
    {

    }
    private void FixedUpdate()
    {
        if(_pickedUp) 
        {
            
        }
    }
}
