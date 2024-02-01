using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.InputSystem.InputSettings;
using UnityEngine.UI;

public class RageController : MonoBehaviour
{
    public RawImage gaugeArrow;

    public float rageValue = 100f;
    public float decreaseRate = 5f;
    public float moneyRageRatio = 0.5f;

    private float gaugeAngle = -76f;
    private float gaugeStep = 2f;


    private float GaugeAngle() // Funció per calcular la rotació segons el rage
    {
        float rageInverse = 100f - rageValue;
        return rageInverse*gaugeStep - 76f;
    }
    private void Start()
    {
        gaugeArrow.transform.rotation = Quaternion.Euler(0f, 0f, GaugeAngle());
        BeakableBehaviour.OnObjectBroken += UpdateRage;
    }

    private void UpdateRage(BeakableBehaviour bb)
    {
        rageValue += bb.Value * moneyRageRatio;
        if(rageValue > 100) rageValue = 100;
        gaugeArrow.transform.rotation = Quaternion.Euler(0f, 0f, GaugeAngle());
    }

    private void Update()
    {
        float decreaseAmount = decreaseRate * Time.deltaTime;
        if (decreaseAmount < rageValue && rageValue > 0)
        {
            rageValue -= decreaseAmount;
            gaugeArrow.transform.rotation = Quaternion.Euler(0f, 0f, GaugeAngle());
        }
    }
}
