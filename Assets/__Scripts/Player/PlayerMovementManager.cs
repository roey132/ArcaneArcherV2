using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Vector2 _movementVector = Vector2.zero;

    [SerializeField] private StatsManager _playerStats;

    private void OnEnable()
    {
        PlayerInputsManager.OnMovementInput += OnMovementInput;
    }
    private void OnDisable()
    {
        PlayerInputsManager.OnMovementInput -= OnMovementInput;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movementVector * _playerStats.GetStatValue(Stat.MovementSpeed);
    }

    private void OnMovementInput(Vector2 movementVector) 
    {
        _movementVector = movementVector;
    }

    
}
