using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "new item data",menuName = "Items/Base Item Data")]
public class ItemData : SerializedScriptableObject
{
    public string Name;
    public string Description;
    public ItemCategory Category;
    public Rarity Rarity;
    public Sprite Sprite;
    public ItemType Type;
    public GameObject itemObject;
}
public enum ItemCategory
{
    Physical,
    Magical,
    Utility
}
public enum Rarity
{
    Common,
    Rare,
    Epic,
    Unique,
    Legendary
}
public enum ItemType
{
    BaseItem,
    StatItem,
    BehaviourItem,
    UniqueItem
}