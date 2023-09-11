using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class GameManager : SerializedMonoBehaviour
{
    public static GameManager Instance;

    [Required]
    [SerializeField] private ProjectileData _baseProjectileData;
    [Required]
    [SerializeField] private GameObject _baseProjectileObject;
    [ShowInInspector] public int CurrentGameDifficulty { get; private set; }
    [ShowInInspector] public int CurrentRoomDifficulty { get; private set; }

    [Header("States")]
    [Required]
    [SerializeField] private GameState _startingGameState;
    [ReadOnly]
    [SerializeField] private GameState _currState;
    [ButtonGroup]
    private void Idle()
    {
        ChangeGameState(GameState.IdleState);
    }
    [ButtonGroup]
    private void Interactive()
    {
        ChangeGameState(GameState.InteractiveState);
    }
    [ButtonGroup]
    private void Combat()
    {
        ChangeGameState(GameState.CombatState);
    }



    public static event Action<GameState> OnGameStateChange;
    public static event Action OnCombatRoomEnd;

    public void EndCombatRoom()
    {
        OnCombatRoomEnd?.Invoke();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        CurrentRoomDifficulty = 1;
        ObjectPoolsManager.Instance.CreateObjectPool(_baseProjectileObject, _baseProjectileData.ProjetileName);
    }
    private void Start()
    {
        ChangeGameState(_startingGameState);
    }
    public void ChangeGameState(GameState state)
    {
        _currState = state;
        print($"GameState changed to: {state}");
        OnGameStateChange?.Invoke(state);
    }




}

public enum GameState
{
    IdleState,
    InteractiveState,
    CombatState
}