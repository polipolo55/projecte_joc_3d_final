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
    private float _fontSize;

    void Start()
    {
        _fontSize = moneyText.fontSize;
        _updateDelay = 1f / updateSpeed;
    }

    IEnumerator UpdateMoney()
    {
        _coroutineActive = true;
        while (_currentMoney < _targetMoney)
        {
            _currentMoney++;
            moneyText.text = "MONEY: $" + _currentMoney.ToString();
            if(_currentMoney%2  == 0) moneyText.fontSize = _fontSize + 6f;
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

    private void Update()
    {
        if(moneyText.fontSize > _fontSize)
        {
            moneyText.fontSize -= Time.deltaTime * 50f;
        }
        if (moneyText.fontSize < _fontSize) moneyText.fontSize = _fontSize;
    }

}
