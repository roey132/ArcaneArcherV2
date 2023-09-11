using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolCleaner : SerializedMonoBehaviour
{
    [SerializeField] private List<GameObject> _enemiesToReturn;
    private void Awake()
    {
        GameFlowManager.OnRoomStateChange += OnRoomEnd;
    }
    private void OnDestroy()
    {
        GameFlowManager.OnRoomStateChange -= OnRoomEnd;
    }
    private void ReturnEnemiesToPool()
    {
        foreach (GameObject enemyPrefab in _enemiesToReturn)
        {
            EnemyData _data = enemyPrefab.GetComponent<EnemyManager>().GetEnemyData();
            ObjectPoolsManager.Instance.ReturnAllObjectsToPool(_data.Name);
        }
    }

    private void OnRoomEnd(RoomState roomState)
    {
        if (roomState != RoomState.RoomEnd) return;
        ReturnEnemiesToPool();
    }
}
