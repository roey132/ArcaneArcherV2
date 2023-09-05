using UnityEngine;

public class BaseEnemyAttackState : ObjectState
{
    [Header("Manager")]
    [SerializeField] private EnemyManager _enemyManager;

    [Header("States")]
    [SerializeField] private ObjectState _idleState;

    public override void OnStateEnd()
    {
    }

    public override void OnStateStart()
    {
    }

    public override ObjectState StateBehaviour()
    {
        print("Attack Performed");
        _enemyManager.AttackPerformed();
        return _idleState;

    }
}
