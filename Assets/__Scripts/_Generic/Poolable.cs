using UnityEngine;

public abstract class Poolable : MonoBehaviour
{
    public string _poolName;
    public virtual void ReleaseSelfToPool() 
    {
        ObjectPoolsManager.Instance.ReleaseObject(_poolName, gameObject);
    }
}
