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
        throw new System.NotImplementedException();
    }
    public override void OnStateStart()
    {
        throw new System.NotImplementedException();
    }
    public override ObjectState StateBehaviour()
    {
        if (_enemyManager.CanAttack())
        {
            return _attackState;
        }
        return _movementState;
    }
}
