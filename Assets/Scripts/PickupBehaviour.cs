using UnityEngine;
using UnityEngine.UI;

public class PickupBehaviour : MonoBehaviour
{
    public Transform headPos;
    public Transform pickupPoint;
    public Transform handPos;
    public RawImage crosshair;
    

    [Header("Params")]
    public float PushForce = 5f;
    public float pickupRange = 5f;
    [Header("Axe")]
    public float extraDamageAxe = 5f;
    public float extraForceAxe = 10f;

    private bool _isPickup = false; //Retorna si es pot agafar un objecte
    private bool _pickedUp = false; //Retorna si s'ha agafat un objecte
    private ObjectGrabbable objectGrabbable = null;

    private void Update()
    {
        if (!_pickedUp)
        {
            if (_isPickup) crosshair.color = Color.red;
            else crosshair.color = Color.white;

            if (Physics.Raycast(headPos.transform.position, headPos.transform.forward, out RaycastHit hitInfo, pickupRange))
            {
                if (hitInfo.transform.TryGetComponent(out objectGrabbable)) 
                {
                    _isPickup = true;
                }
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
            if (!_pickedUp) 
            {
                if(objectGrabbable.special)
                {
                    objectGrabbable.GrabSpecial(handPos);
                }
                else objectGrabbable.Grab(pickupPoint);
                _pickedUp = true;
            } 
            else
            {
                if(!objectGrabbable.special)
                {
                    objectGrabbable.Drop();
                    if (push) objectGrabbable.Push(headPos, PushForce);
                    _pickedUp = false;
                }
                else
                {
                    if (!push) 
                    {
                        objectGrabbable.Drop();
                        _pickedUp = false;
                    }
                    
                }
            }
        }
    }
    public bool IsSpecial() 
    {
        if (objectGrabbable == null) return false;
        return objectGrabbable.special;
    }
    public float GetExtraForce() { return extraForceAxe; }
    public float GetExtraDamage() { return extraDamageAxe; }
    public bool HoldingObject() { return _pickedUp; }
}
