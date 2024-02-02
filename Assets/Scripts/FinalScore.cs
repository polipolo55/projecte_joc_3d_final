using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    private TMP_Text _score;

    private void Awake()
    {
        _score = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _score.text = "$" + GameManager.instance.score.ToString();
    }
}
