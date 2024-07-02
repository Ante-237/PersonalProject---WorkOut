using System;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "VoidEventSO")]
[System.Serializable]
public class VoidEventSO : ScriptableObject
{
    public event UnityAction UpdateScore;

    public void RaiseEvent()
    {
        if (UpdateScore != null)
        {
            UpdateScore.Invoke();
        }     
    }
}
