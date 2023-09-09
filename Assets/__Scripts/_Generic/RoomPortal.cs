using Sirenix.OdinInspector;
using UnityEngine;

public class RoomPortal : SerializedMonoBehaviour
{
    [SerializeField] private PortalData _portalData;
    [SerializeField] private SpriteRenderer _portalIcon;
    [SerializeField] private SpriteRenderer _portalRender;

    public void InitPortal(PortalData portalData)
    {
        _portalData = portalData;
        _portalIcon.sprite = _portalData.PortalIcon;
        gameObject.SetActive(true);
    }

    public void ActivatePortal()
    {
        GameManager.Instance.ChangeGameState(_portalData.InRoomGameState);
        gameObject.SetActive(false);
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
