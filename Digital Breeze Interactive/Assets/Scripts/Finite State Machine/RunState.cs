using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class RunState : NinjaState
{
    public AnimationClip anim;
    public float moveSpeed;
    public override void OnEnableState()
    {
        stateManager.animator.Play(anim.name);
    }

    public override void FixedUpdateState()
    {
        stateManager.rb.velocity = new Vector2(stateManager.horizontal * moveSpeed, stateManager.rb.velocity.y);
        if (stateManager.horizontal == 0)
        {
            stateManager.SelectState(stateManager.idleState);
        }
    }

    public override void OnDisableState()
    {
        base.OnDisableState();
    }
}
