using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public int moneyAmount = 0;
    public List<GameObject> brokenObjects = new List<GameObject>();

    private UIMoney _moneyUI = null;

    private void Awake()
    {
        TryGetComponent<UIMoney>(out _moneyUI);
    }
    private void Start()
    {
        BeakableBehaviour.OnObjectBroken += UpdateMoney;
    }

    private void UpdateMoney(BeakableBehaviour bb)
    {
        moneyAmount += bb.Value;
        brokenObjects.Add(bb.gameObject);
        if(_moneyUI != null)
        {
            _moneyUI.SetTargetMoney(moneyAmount);
        }
    }
}
