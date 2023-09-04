using UnityEngine;

public abstract class ObjectState : MonoBehaviour
{
    public abstract ObjectState StateBehaviour();
    public abstract void OnStateStart();
    public abstract void OnStateEnd();
}
