using UnityEngine;

public class PlayerBaseStats : MonoBehaviour
{
    [Header("Damage Stats")]
    [SerializeField] public float MovementSpeed;

    [SerializeField] public float AttackDamage;
    [SerializeField] public float MagicDamage;
    [SerializeField] public float PhysicalDamageMultiplierPct;
    [SerializeField] public float MagicalDamageMultiplierPct;
    [SerializeField] public float CriticalRatePct;
    [SerializeField] public float CriticalDamageMultiplierPct;

    [Header("Bow Stats")]
    [SerializeField] public float AttackSpeed;
    [SerializeField] public float NumberOfArrows;

    [Header("Spell Stats")]
    [SerializeField] public float CastCooldownReductionPct;

    [Header("Health Stats")]
    [SerializeField] public float StartingHealth;

    [Header("Dash Stats")]
    [SerializeField] public float DashCooldown;
    [SerializeField] public float DashDistance;
}
