using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : SerializedMonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] private List<EnemyData> _availableEnemies;
    [Required]
    [SerializeField] private Collider2D SpawnArea;
    [Title("Debugging")]
    [Button]
    private void ManualSpawnEnemy(EnemyData _enemyDataToDebug)
    {
        SpawnEnemy(1000, Vector3.zero, _enemyDataToDebug);
    }
    [Button]
    private void ManualSpawnEvent(int numToSpawn, float maxEnemyValue, float spawnRadius, Vector3 spawnCenter, float timeBetweenSpawn = 0.2f, EnemyData enemyToSpawn = null)
    {
        StartCoroutine(SpawnEvent(numToSpawn, maxEnemyValue, spawnRadius, spawnCenter, timeBetweenSpawn, enemyToSpawn));
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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

    public void InvokeSpawnEvent(int numToSpawn, float maxEnemyValue, float spawnRadius, Vector3 spawnCenter, float timeBetweenSpawn = 0.2f, EnemyData enemyToSpawn = null)
    {
        StartCoroutine(SpawnEvent(numToSpawn, maxEnemyValue, spawnRadius, spawnCenter, timeBetweenSpawn, enemyToSpawn));
    }
    private IEnumerator SpawnEvent(int numToSpawn, float maxEnemyValue, float spawnRadius, Vector3 spawnCenter, float timeBetweenSpawn = 0.2f, EnemyData enemyToSpawn = null)
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            Vector3 spawnPoint = PointGenerator.GetRandomPointInArea(spawnCenter,spawnRadius,SpawnArea);
            SpawnEnemy(maxEnemyValue, spawnPoint, enemyToSpawn);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
