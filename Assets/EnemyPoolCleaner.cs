using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolCleaner : SerializedMonoBehaviour
{
    [SerializeField] private List<GameObject> _enemiesToReturn;
    private void Awake()
    {
        GameManager.OnCombatRoomEnd += ReturnEnemiesToPool;
    }
    private void OnDestroy()
    {
        GameManager.OnCombatRoomEnd -= ReturnEnemiesToPool;
    }
    private void ReturnEnemiesToPool()
    {
        foreach (GameObject enemyPrefab in _enemiesToReturn)
        {
            EnemyData _data = enemyPrefab.GetComponent<EnemyManager>().GetEnemyData();
            ObjectPoolsManager.Instance.ReturnAllObjectsToPool(_data.Name);
        }
    }
}
