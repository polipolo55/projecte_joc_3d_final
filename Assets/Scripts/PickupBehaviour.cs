using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PickupBehaviour : MonoBehaviour
{
    public Transform headPos;
    public Transform pickupPoint;
    public RawImage crosshair;

    [Header("Params")]
    public float PushForce = 5f;
    public float pickupRange = 5f;

    private bool _isPickup = false; //Retorna si es pot agafar un objecte
    private bool _pickedUp = false; //Retorna si s'ha agafat un objecte
    [SerializeField]
    private ObjectGrabbable objectGrabbable = null;

    private void Update()
    {
        if (!_pickedUp)
        {
            if (_isPickup) crosshair.color = Color.red;
            else crosshair.color = Color.white;

            if (Physics.Raycast(headPos.transform.position, headPos.transform.forward, out RaycastHit hitInfo, pickupRange))
            {
                if (hitInfo.transform.TryGetComponent(out objectGrabbable)) _isPickup = true;
                else _isPickup = false;
            }
            else _isPickup = false;
        }
        else if (objectGrabbable == null) 
        {
            _pickedUp = false;
        }
    }

    public void Grab(bool push)
    {
        if (_isPickup && objectGrabbable != null)
        {
            _pickedUp = !_pickedUp;
            if (_pickedUp) objectGrabbable.Grab(pickupPoint);
            else
            {
                objectGrabbable.Drop();
                if (push) objectGrabbable.Push(headPos, PushForce);
            }
        }
    }
    public bool HoldingObject() { return _pickedUp; }
}
