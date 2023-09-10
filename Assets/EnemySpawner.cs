using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SerializedMonoBehaviour
{
    [SerializeField] private List<EnemyData> _availableEnemies;

    [Title("Debugging")]
    [Button]
    private void ManualSpawnEnemy(EnemyData _enemyDataToDebug)
    {
        SpawnEnemy(1000, Vector3.zero, _enemyDataToDebug);
    }
    
    private EnemyData GetEnemyDataByValue(float maxEnemyValue)
    {
        // generate a list of all enemies within the enemy value
        List<EnemyData> inValueList = new List<EnemyData>();
        foreach (EnemyData enemyData in _availableEnemies)
        {
            if (enemyData.EnemyValue <= maxEnemyValue)
            {
                inValueList.Add(enemyData);
            }
        }
        // check if viable enemy list is empty
        if (inValueList.Count == 0) { return null; }

        // get a random enemy within the viable list
        int randomIndex = Random.Range(0, inValueList.Count);
        EnemyData randomData = inValueList[randomIndex];
        return randomData;
    }

    private void SpawnEnemy(float maxEnemyValue, Vector3 spawnPosition, EnemyData enemyData= null)
    {
        if (enemyData == null) 
        { 
            enemyData = GetEnemyDataByValue(maxEnemyValue); 
        }

        GameObject enemyObject = ObjectPoolsManager.Instance.PullObject(enemyData.Name);

        enemyObject.transform.position = spawnPosition;
    }

    public void SpawnEvent(int numToSpawn, float maxEnemyValue, float spawnRadius, Vector3 spawnCenter, float timeBetweenSpawn = 0.2f, EnemyData enemyToSpawn = null)
    {
        
    }

}
