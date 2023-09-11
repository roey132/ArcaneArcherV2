using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class TimerRoomManager : SerializedMonoBehaviour
{
    [SerializeField] private AnimationCurve _maxEnemiesCurve;
    [SerializeField] private AnimationCurve _timeBetweenSpawnsCurve;
    [Required, SerializeField] private int _startTimer;
    [Required, SerializeField] private Collider2D _spawnArea;

    [ShowInInspector] private int _maxEnemiesSpawned;

    [ShowInInspector] private float _maxTimeBetweenSpawns;

    [ShowInInspector] private float _nextSpawnTime;
    [ShowInInspector] private float _maxEnemyValue;

    public static event Action OnTimerRoomStart;
    public static event Action OnTimerRoomEnd;

    private bool _roomActive;

    [Button]
    private void ManualStartRoom()
    {
        GameFlowManager.InitRoomStates(RoomType.TimerCombat, GameState.InteractiveState, RoomState.RoomStart);
    }

    [Title("Debugging")]
    [GUIColor("Green"), SerializeField, DisplayAsString(FontSize = 25, Alignment = TextAlignment.Left)] 
    private float _roomTimer;

    private void Awake()
    {
        GameFlowManager.OnRoomTypeChange += OnRoomTypeChange;
    }
    private void OnDestroy()
    {
        GameFlowManager.OnRoomTypeChange -= OnRoomTypeChange;
    }
    private void OnEnable()
    {
        GameFlowManager.OnRoomStateChange += OnRoomStateChange;
    }
    private void OnDisable()
    {
        GameFlowManager.OnRoomStateChange -= OnRoomStateChange;
    }

    void Update()
    {
        if (!_roomActive) return;

        _roomTimer -= Time.deltaTime;
        if (_roomTimer < 0)
        {
            RoomEnd();
        }
        if (_nextSpawnTime > Time.time) return;
        _nextSpawnTime = Time.time + _maxTimeBetweenSpawns * _timeBetweenSpawnsCurve.Evaluate((_startTimer - _roomTimer) / _startTimer);
        Vector3 centerPoint = PointGenerator.GetRandomPointInArea(Vector3.zero, 30, _spawnArea);
        int numToSpawn = Mathf.RoundToInt(_maxEnemiesSpawned * _maxEnemiesCurve.Evaluate((_startTimer - _roomTimer) / _startTimer));
        float spawnRadius = UnityEngine.Random.Range(2, 4);
        print($"Spawning {numToSpawn} Enemies");
        EnemySpawner.Instance.InvokeSpawnEvent(numToSpawn, _maxEnemyValue, spawnRadius, centerPoint);
    }

    private void RoomStart()
    {
        _roomTimer = _startTimer;
        _maxEnemiesSpawned = DifficultyCalculations.MaxEnemiesSpawned(GameManager.Instance.CurrentRoomDifficulty);
        _maxTimeBetweenSpawns = DifficultyCalculations.MaxTimeBetweenSpawns(GameManager.Instance.CurrentRoomDifficulty);
        _maxEnemyValue = DifficultyCalculations.DifficultyValue(GameManager.Instance.CurrentRoomDifficulty);
        _roomActive = true;
        OnTimerRoomStart?.Invoke();
    }
    private void RoomEnd()
    {
        // TODO : Handle Combat room ending better
        print("Timer Room Ended");
        GameFlowManager.Instance.ChangeRoomState(RoomState.RoomEnd);
        gameObject.SetActive(false);
        OnTimerRoomEnd?.Invoke();
    }

    private void OnRoomTypeChange(RoomType type)
    {
        if (type != RoomType.TimerCombat) 
        {
            print("room type is not done correctly");
            gameObject.SetActive(false);
            return;
        }
        print("activating timer room");
        gameObject.SetActive(true);
    }

    private void OnRoomStateChange(RoomState state)
    {
        if (state != RoomState.RoomActive) return;
        RoomStart();
    }
}
