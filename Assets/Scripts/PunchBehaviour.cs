using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBehaviour : MonoBehaviour
{
    public Transform headPos;

    public float punchForce = 10f;
    public float punchRange = 5f;
    public void Punch()
    {
        if (Physics.Raycast(headPos.transform.position, headPos.transform.forward, out RaycastHit hitInfo, punchRange))
        {
            if (hitInfo.transform.TryGetComponent(out ObjectPunchable punchableComponent))
            {
                punchableComponent.Punch(headPos, punchForce);
            }
        }
    }
}
