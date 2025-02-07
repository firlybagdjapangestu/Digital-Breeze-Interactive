using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;

public abstract class NinjaState : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator animator;
    protected NinjaStateManager stateManager;
    public bool isComplete { get; protected set; }

    public virtual void OnEnableState() { }
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }
    public virtual void OnDisableState() { }

    public virtual void OnTriggerEnter2DState(Collider2D collider) { }

    public void InitializedComponent(NinjaStateManager _stateManager)
    {
        stateManager = _stateManager;
    }
}
