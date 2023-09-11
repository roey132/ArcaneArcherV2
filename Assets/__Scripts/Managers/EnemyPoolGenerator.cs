using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolGenerator : SerializedMonoBehaviour
{
    [SerializeField] private List<GameObject> _enemiesToPool;
    void Start()
    {
        foreach (GameObject enemyPrefab in _enemiesToPool)
        {
            EnemyData _data = enemyPrefab.GetComponent<EnemyManager>().GetEnemyData();
            ObjectPoolsManager.Instance.CreateObjectPool(enemyPrefab, _data.Name);
        }
    }
}
