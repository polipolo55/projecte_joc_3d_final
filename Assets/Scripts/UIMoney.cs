using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMoney : MonoBehaviour
{
    public TMP_Text moneyText;

    [Header("Params")]
    public float updateSpeed = 1000f;

    private int _currentMoney = 0;
    private int _targetMoney = 0;
    private float _updateDelay = 0;
    private bool _coroutineActive = false;

    void Start()
    {
        // You can start the coroutine to update the money incrementally
        _updateDelay = 1f / updateSpeed;
    }

    IEnumerator UpdateMoney()
    {
        _coroutineActive = true;
        while (_currentMoney < _targetMoney)
        {
                _currentMoney++;
                moneyText.text = "MONEY: $" + _currentMoney.ToString();
                yield return new WaitForSeconds(_updateDelay);
        }
        _coroutineActive = false;
    }

    // Method to update the target money amount
    public void SetTargetMoney(int amount)
    {
        _targetMoney = amount;
        if (!_coroutineActive) StartCoroutine(UpdateMoney());
    }

}
