using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameFlowManager : SerializedMonoBehaviour
{
    public static GameFlowManager Instance;

    public static event Action<RoomState> OnRoomStateChange;
    public static event Action<GameState> OnGameStateChange;
    public static event Action<RoomType> OnRoomTypeChange;

    [DisplayAsString, SerializeField] public GameState CurrGameState { get; private set; }
    [DisplayAsString, SerializeField] public RoomState CurrRoomState { get; private set; }
    [DisplayAsString, SerializeField] public RoomType CurrRoomType { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public static void InitRoomStates(RoomType roomType, GameState gameState, RoomState roomState)
    {
        Instance.ChangeRoomType(roomType);
        Instance.ChangeGameState(gameState);
        Instance.ChangeRoomState(roomState);
    }

    public void ChangeRoomState(RoomState newState)
    {
        CurrRoomState = newState;
        print($"RoomState changed to: {newState}");
        OnRoomStateChange?.Invoke(newState);
    }

    public void ChangeGameState(GameState state)
    {
        CurrGameState = state;
        print($"GameState changed to: {state}");
        OnGameStateChange?.Invoke(state);
    }

    public void ChangeRoomType(RoomType newType)
    {
        CurrRoomType = newType;
        print($"RoomType changed to: {newType}");
        OnRoomTypeChange?.Invoke(newType);
    }
}
public enum RoomState
{
    RoomStart,
    RoomActive,
    RoomEnd
}

public enum GameState
{
    IdleState,
    InteractiveState,
    CombatState
}