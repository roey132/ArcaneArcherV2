using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsManager : MonoBehaviour
{
    private PlayerInputs _playerInputs;

    public static event Action<Vector2> OnMovementInput;
    public static event Action OnDashInput;
    private float testTimer = 3;
    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
        _playerInputs.Player.Movement.performed += OnMovementPerformed;
        _playerInputs.Player.Movement.canceled += OnMovementCanceled;
        _playerInputs.Player.Dash.performed += OnDashPerformed;
    }
    private void OnDisable()
    {
        _playerInputs.Disable();
        _playerInputs.Player.Movement.performed -= OnMovementPerformed;
        _playerInputs.Player.Movement.canceled -= OnMovementCanceled;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
