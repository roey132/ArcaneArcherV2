using UnityEngine;

[CreateAssetMenu(fileName ="Projectile Data", menuName = "Base Projectile")]
public class ProjectileData : ScriptableObject
{
    public string ProjetileName;
    public float Speed;
    public float DamageMultiplier;
    public int PenetrationCount;
    public Sprite ProjectileSprite;
}
