using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "Portal Data", menuName = "Generics/Portal Data")]
public class PortalData : SerializedScriptableObject
{
    [Required]
    public string PortalName;
    [Required]
    public PortalType PortalType;
    [Required]
    public GameState InRoomGameState;
    [Required]
    public Sprite PortalIcon;
}

public enum PortalType
{
    TimerCombat,
    ValueCombat,
    Shop,
    Heal,
    Treasure
}
