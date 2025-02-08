using UnityEngine;

public abstract class NinjaState : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator animator;
    protected NinjaStateManager stateManager;
    public bool isComplete { get; protected set; }

    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }
    public virtual void ExitState() { }

    public virtual void OnTriggerEnter2DState(Collider2D collider) { }

    public void InitializedComponent(NinjaStateManager _stateManager)
    {
        stateManager = _stateManager;
    }
}


