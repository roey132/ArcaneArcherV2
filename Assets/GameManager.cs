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
    [ButtonGroup]
    private void Idle()
    {
        GameFlowManager.Instance.ChangeGameState(GameState.IdleState);
    }
    [ButtonGroup]
    private void Interactive()
    {
        GameFlowManager.Instance.ChangeGameState(GameState.InteractiveState);
    }
    [ButtonGroup]
    private void Combat()
    {
        GameFlowManager.Instance.ChangeGameState(GameState.CombatState);
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
        GameFlowManager.Instance.ChangeGameState(_startingGameState);
    }





}

