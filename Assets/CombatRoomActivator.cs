using System.Collections.Generic;
using UnityEngine;

public class CombatRoomActivator : Interactable
{
    [SerializeField] private List<RoomType> _activateOnRoomTypes; 
    private void Awake()
    {
        GameFlowManager.OnRoomTypeChange += OnRoomTypeChange;
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        GameFlowManager.OnRoomTypeChange -= OnRoomTypeChange;
    }

    public override void Interact()
    {
        GameFlowManager.Instance.ChangeRoomState(RoomState.RoomActive);
        GameFlowManager.Instance.ChangeGameState(GameState.CombatState);
        gameObject.SetActive(false);
    }

    private void OnRoomTypeChange(RoomType roomType)
    {
        if (!_activateOnRoomTypes.Contains(roomType)) return;
        gameObject.SetActive(true);
    }
}
