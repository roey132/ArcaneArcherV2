using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class RoomPortal : Interactable
{
    public static event Action OnPortalInteraction;

    [SerializeField] private PortalData _portalData;
    [SerializeField] private SpriteRenderer _portalIcon;
    [SerializeField] private SpriteRenderer _portalRender;

    [Title("Debugging")]
    [Button]
    private void ActivatePortal()
    {
        Interact();
    }
    public void InitPortal(PortalData portalData)
    {
        _portalData = portalData;
        _portalIcon.sprite = _portalData.PortalIcon;
        gameObject.SetActive(true);
    }

    public override void Interact()
    {
        GameManager.Instance.ChangeGameState(_portalData.InRoomGameState);
        gameObject.SetActive(false);
        OnPortalInteraction.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        _portalRender.color = Color.green;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        _portalRender.color = Color.white;
    }
}
