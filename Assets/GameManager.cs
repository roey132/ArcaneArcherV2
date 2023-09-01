using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ProjectileData _baseProjectileData;
    [SerializeField] private GameObject _baseProjectileObject;
    private void Awake()
    {
        ObjectPoolsManager.Instance.CreateObjectPool(_baseProjectileObject, _baseProjectileData.ProjetileName);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
