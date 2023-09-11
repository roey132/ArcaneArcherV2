using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Sirenix.OdinInspector;



public class ObjectPoolsManager : SerializedMonoBehaviour
{
    public static ObjectPoolsManager Instance;

    [SerializeField] private Dictionary<string, ObjectPool<GameObject>> _pools;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _pools = new Dictionary<string, ObjectPool<GameObject>>();
    }

    public void CreateObjectPool(GameObject objectPrefab, string objectName, int baseObjectCount = 100, int maxObjectCount = 300)
    {
        Transform poolTransform = new GameObject(objectName).transform;
        poolTransform.SetParent(transform);
        ObjectPool<GameObject> objectPool = new ObjectPool<GameObject>(
            () => { return Instantiate(objectPrefab, poolTransform); },
            gameObject => { gameObject.SetActive(true); },
            gameObject => { gameObject.SetActive(false); },
            gameObject => { Destroy(gameObject); },
            false,
            baseObjectCount,
            maxObjectCount);
        _pools.Add(objectName, objectPool);
    }

    public void DestroyObjectPool(string objectName)
    {
        _pools[objectName].Dispose();
        _pools.Remove(objectName);
    }

    public GameObject PullObject(string objectName)
    {
        return _pools[objectName].Get();
    }

    public void ReleaseObject(string objectName, GameObject gameObject)
    {
        _pools[objectName].Release(gameObject);
    }
    public void ReturnAllObjectsToPool(string objectName)
    {
        Transform currPool = transform.Find(objectName);
        int childCount = currPool.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            ReleaseObject(objectName, currPool.GetChild(i).gameObject);
        }
    }
}
