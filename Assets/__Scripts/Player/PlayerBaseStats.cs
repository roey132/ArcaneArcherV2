using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseStats : SerializedMonoBehaviour
{
    [Header("Generic Stats")]
    [SerializeField] public Dictionary<Stat, float> BasePlayerStats;

    [Header("Health Stats")]
    [SerializeField] public float StartingHealth;

    [Header("Dash Stats")]
    [SerializeField] public float DashCooldown;
    [SerializeField] public float DashDistance;
}
