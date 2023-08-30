using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBaseStats : MonoBehaviour
{
    [SerializeField] public float AttackDamage;
    [SerializeField] public float MagicDamage;
    [SerializeField] public float PhysicalDamageMultiplierPct;
    [SerializeField] public float MagicalDamageMultiplierPct;
    [SerializeField] public float AttackSpeed;
    [SerializeField] public float CastCooldownReductionPct;
    [SerializeField] public float MovementSpeed;
    [SerializeField] public float CriticalRatePct;
    [SerializeField] public float CriticalDamageMultiplierPct;
    [SerializeField] public float NumberOfArrows;
}
