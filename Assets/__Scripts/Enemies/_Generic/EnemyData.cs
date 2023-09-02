using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseEnemyData",menuName="Enemy/Base Enemy Data")] 
public class EnemyData : SerializedScriptableObject
{
    [Header("Enemy")]
    public string Name;
    public float StartingHealth;
    [Header("Base Stats")]
    public Dictionary<Stat, float> BaseStats;

    [Header("Unique Enemy Variables")]
    public float ScaleMultiplier;
    public int Rarity;
    public Sprite ReferenceSprite;
}