using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "new item data", menuName = "Items/Stat Item Data")]
public class StatItemData : ItemData
{
    public Dictionary<Stat, float> Stats;
}
