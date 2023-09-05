using Sirenix.OdinInspector;
using UnityEngine;

public abstract class Poolable : SerializedMonoBehaviour
{
    public string _poolName;
    public virtual void ReleaseSelfToPool() 
    {
        ObjectPoolsManager.Instance.ReleaseObject(_poolName, gameObject);
    }
}
