using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBehaviour : MonoBehaviour
{
    public Transform headPos;

    public ObjectPunchable punchable;

    public float punchForce = 10f;
    public float punchRange = 5f;
    public float punchDamage = 10f;

    private float realDamage;
    private float realForce;

    private void Awake()
    {
        ResetValues();
    }

    private void ResetValues()
    {
        realDamage = punchDamage;
        realForce = punchForce;
    }

    public void Punch()
    {
        if (Physics.Raycast(headPos.transform.position, headPos.transform.forward, out RaycastHit hitInfo, punchRange))
        {
            if (hitInfo.transform.TryGetComponent(out ObjectPunchable punchableComponent))
            {
                punchable = punchableComponent;
                punchableComponent.Punch(headPos, realForce);
                BeakableBehaviour bb = punchableComponent.GetComponentInParent<BeakableBehaviour>();
                if (bb != null) bb.SubtractHealth(realDamage);
            }
        }
    }

    public void Punch(float extraForce, float extraDamage)
    {
        realDamage = punchDamage + extraDamage;
        realForce = punchForce + extraForce;
        Punch();
        ResetValues();
    }

    
}
