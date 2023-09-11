using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "Portal Data", menuName = "Generics/Portal Data")]
public class PortalData : SerializedScriptableObject
{
    [Required]
    public string PortalName;
    [Required]
    public RoomType RoomType;
    [Required]
    public GameState InRoomGameState;
    [Required]
    public Sprite PortalIcon;
}

public enum RoomType
{
    TimerCombat,
    ValueCombat,
    Shop,
    Heal,
    Treasure
}
