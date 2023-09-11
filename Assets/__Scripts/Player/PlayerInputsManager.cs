using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsManager : MonoBehaviour
{
    public static PlayerInputsManager Instance;

    private PlayerInputs _playerInputs;

    public static event Action<Vector2> OnMovementInput;
    public static event Action OnDashInput;
    public static event Action OnInteractInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        GameFlowManager.OnGameStateChange += OnGameStateChange;
        _playerInputs = new PlayerInputs();
    }
    private void OnDestroy()
    {
        GameFlowManager.OnGameStateChange -= OnGameStateChange;
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
        _playerInputs.Player.Movement.performed += OnMovementPerformed;
        _playerInputs.Player.Movement.canceled += OnMovementCanceled;
        _playerInputs.Player.Dash.performed += OnDashPerformed;
        _playerInputs.Player.Interact.performed += OnInteractPerformed;
    }
    private void OnDisable()
    {
        _playerInputs.Disable();
        _playerInputs.Player.Movement.performed -= OnMovementPerformed;
        _playerInputs.Player.Movement.canceled -= OnMovementCanceled;
        _playerInputs.Player.Dash.performed -= OnDashPerformed;
        _playerInputs.Player.Interact.performed -= OnInteractPerformed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext inputValue)
    {
        OnMovementInput?.Invoke(inputValue.ReadValue<Vector2>());
    }
    private void OnMovementCanceled(InputAction.CallbackContext inputValue)
    {
        OnMovementInput?.Invoke(Vector2.zero);
    }
    private void OnDashPerformed(InputAction.CallbackContext inputValue)
    {
        OnDashInput?.Invoke();
    }
    private void OnUseArrowHold()
    {

    }
    private void OnInteractPerformed(InputAction.CallbackContext inputValue)
    {
        OnInteractInput?.Invoke();
    }

    private void OnGameStateChange(GameState state)
    {
        gameObject.SetActive(state != GameState.IdleState);
        print($"Player Inputs Enabled: {state != GameState.IdleState}");
    }
}
