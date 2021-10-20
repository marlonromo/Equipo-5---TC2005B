using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Contract : MonoBehaviour
{
    public int IDContract;
    public string title;
    public string description;
    public int steelRequirement;
    public int moneyReward;
    public float timeRemaining;
    public double penalization;
    public bool success;
    public bool isActive;
}
