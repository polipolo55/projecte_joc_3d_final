using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackEvent : MonoBehaviour
{
    public UnityEvent attack;
    public void SendEvent()
    {
        attack.Invoke();
    }
}
