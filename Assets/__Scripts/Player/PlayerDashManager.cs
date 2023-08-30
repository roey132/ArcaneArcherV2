using System;
using System.Collections;
using UnityEngine;

public class PlayerDashManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    private Vector2 _dashDirection = new Vector2(1,0);

    public static event Action OnTeleportStart;
    public static event Action OnTeleportEnd;

    [SerializeField] private float _dashDistance; //TODO: Handle dash distance and cooldown through a stat script
    [SerializeField] private float _dashCooldown;
    private float _dashTimer;

    [SerializeField] private LayerMask _wallsLayerMask;

    private void Awake()
    {

    }
    private void OnEnable()
    {
        PlayerInputsManager.OnMovementInput += SetDashDirection;
        PlayerInputsManager.OnDashInput += Dash;
    }
    private void OnDisable()
    {
        PlayerInputsManager.OnMovementInput -= SetDashDirection;
        PlayerInputsManager.OnDashInput -= Dash;
    }

    void Update()
    {
        _dashTimer -= Time.deltaTime;
    }
    private void SetDashDirection(Vector2 dashDirection)
    {
        if (dashDirection == Vector2.zero) return;
        _dashDirection = dashDirection;
    }

    private void Dash()
    {
        if (_dashTimer > 0) return;
        OnTeleportStart?.Invoke();
        _dashTimer = _dashCooldown;
        float currDashDistance = _dashDistance;

        // handle dash distance if dashing towards a wall
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _dashDirection, _dashDistance, _wallsLayerMask);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Wall"))
            {
                float hitDistance = hit.distance;
                if (hitDistance < _dashDistance)
                {
                    currDashDistance = hitDistance;
                }
            }
        }

        _rb.position += currDashDistance * _dashDirection;
        StartCoroutine(DelayedTeleportEnd());
    }
    public IEnumerator DelayedTeleportEnd()
    {
        yield return new WaitForSeconds(0.1f);
        OnTeleportEnd?.Invoke();
    }
}
