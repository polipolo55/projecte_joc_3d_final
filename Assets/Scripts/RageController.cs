using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputSettings;

public class RageController : MonoBehaviour
{
    public float rageValue = 100f;
    public float decreaseRate = 5f;
    public float moneyRageRatio = 0.5f;

    private void Start()
    {
        BeakableBehaviour.OnObjectBroken += UpdateRage;
    }

    private void UpdateRage(BeakableBehaviour bb)
    {
        rageValue += bb.Value * moneyRageRatio;
        if(rageValue > 100) rageValue = 100;
    }

    private void Update()
    {
        float decreaseAmount = decreaseRate * Time.deltaTime;
        if (decreaseAmount < rageValue && rageValue > 0)
        {
            rageValue -= decreaseAmount;
        }
    }
}
