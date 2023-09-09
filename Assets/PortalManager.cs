using Sirenix.OdinInspector;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalManager : SerializedMonoBehaviour
{
    [InfoBox("List of all available portals")]
    [SerializeField] private List<PortalData> _portalDatas;
    [SerializeField] private GameObject _portalPrefab;

    [SerializeField] private float _distanceBetweenPortals;

    private List<GameObject> _generatedPortals;

    [Button]
    public void GeneratePortalsTester()
    {
        GeneratePortals();
    }
    private void Awake()
    {
        _generatedPortals = new List<GameObject>();
    }

    private void OnEnable()
    {
        RoomPortal.OnPortalInteraction += OnPortalInteraction;
    }
    private void OnDisable()
    {
        RoomPortal.OnPortalInteraction -= OnPortalInteraction;
    }

    private void GeneratePortal(PortalData portalData)
    {
        GameObject currPortal = Instantiate(_portalPrefab);
        _generatedPortals.Add(currPortal);
        RoomPortal roomPortal = currPortal.GetComponent<RoomPortal>();
        roomPortal.InitPortal(portalData);
    }

    private PortalData GetRandomPortalData()
    {
        int randomIndex = Random.Range(0, _portalDatas.Count);
        
        return _portalDatas[randomIndex];
    }

    private void GeneratePortals()
    {
        DestroyExistingPortals();
        _generatedPortals.Clear();
        int portalCount = Random.Range(1, 4);
        for (int i = 0; i < portalCount; i++)
        {
            GeneratePortal(GetRandomPortalData());
        }
        SetPortalPositions(portalCount);
    }
    private void SetPortalPositions(int portalCount)
    {
        float totalDistance = (portalCount - 1)* _distanceBetweenPortals;
        float startingXOffset = -(totalDistance / 2f);

        for (int i = 0; i < portalCount; i++)
        {
            _generatedPortals[i].transform.position = transform.position + new Vector3(startingXOffset + _distanceBetweenPortals * i, 0);
        }
    }
    private void DestroyExistingPortals()
    {
        if (_generatedPortals.Count == 0) return;
        foreach (GameObject portalObject in _generatedPortals)
        {
            Destroy(portalObject);
        }
    }

    private void OnPortalInteraction()
    {
        DestroyExistingPortals();
    }
}
