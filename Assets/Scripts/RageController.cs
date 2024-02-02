
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RageController : MonoBehaviour
{
    public RawImage gaugeArrow;

    public float rageValue = 100f;
    public float decreaseRate = 5f;
    public float moneyRageRatio = 0.5f;

    private float gaugeAngle =- 76f;
    private float gaugeStep = 2.6f;

    [SerializeField]
    private float _tmp;
    [SerializeField]
    private bool _ended = false;


    private float GaugeAngle() // Funció per calcular la rotació segons el rage
    {
        float rageInverse = 100f - rageValue;
        _tmp = rageInverse * gaugeStep + gaugeAngle;
        return rageInverse*gaugeStep + gaugeAngle;
    }
    private void Start()
    {
        gaugeArrow.transform.rotation = Quaternion.Euler(0f, 0f, GaugeAngle());
        BeakableBehaviour.OnObjectBroken += UpdateRage;
    }

    private void UpdateRage(BeakableBehaviour bb)
    {
        if(_ended) return;
        rageValue += bb.Value * moneyRageRatio;
        if(rageValue > 100) rageValue = 100;
        gaugeArrow.transform.rotation = Quaternion.Euler(0f, 0f, GaugeAngle());
    }

    private void Update()
    {
        if(_ended) SceneManager.LoadScene("Endscreen");
        float decreaseAmount = decreaseRate * Time.deltaTime;
        rageValue -= decreaseAmount;
        if(rageValue <= 0) _ended = true;
        gaugeArrow.transform.rotation = Quaternion.Euler(0f, 0f, GaugeAngle());
    }
}
