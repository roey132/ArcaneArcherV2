using UnityEngine;

public class StateManager : MonoBehaviour
{
    [Header("States")]
    [SerializeField] private ObjectState _startingState;
    [SerializeField] private ObjectState _currState;

    private ObjectState _newState;
    private void Start()
    {
        _currState = _startingState;
    }
    void FixedUpdate()
    {
        ActivateCurrentState();
    }
    private void ActivateCurrentState()
    {
        _newState = _currState.StateBehaviour();

        if (_newState != null)
        {
            // activate the state end function
            _currState.OnStateEnd();

            // activate the new state start function
            _currState.OnStateStart();

            UpdateCurrState(_newState);

        }
    }
    private void UpdateCurrState(ObjectState state)
    {
        _currState = state;
        _newState = null;
        print($"state changed to {state}");
    }
}
