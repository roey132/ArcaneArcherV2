using UnityEngine;

public class BaseEnemyIdleState : ObjectState
{
    [Header("Manager")]
    [SerializeField] private EnemyManager _enemyManager;

    [Header("States")]
    [SerializeField] private ObjectState _movementState;
    [SerializeField] private ObjectState _attackState;

    public override void OnStateEnd()
    {
    }
    public override void OnStateStart()
    {
    }
    public override ObjectState StateBehaviour()
    {
        if (_attackState != null)
        {
            if (_enemyManager.CanAttack())
            {
                return _attackState;
            }
        }
        if (_movementState != null)
        {
            return _movementState;
        }
        return null;
    }
}
