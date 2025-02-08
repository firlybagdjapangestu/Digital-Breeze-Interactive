using System.ComponentModel;
using UnityEngine;

public class JumpState : NinjaState
{
    public AnimationClip anim;
    public float jumpForce;

    public override void EnterState()
    {
        stateManager.animator.Play(anim.name);
        stateManager.rb.velocity = new Vector2(stateManager.rb.velocity.x, jumpForce);
    }

    public override void UpdateState()
    {
        if (stateManager.isGrounded)
        {
            if (Mathf.Abs(stateManager.horizontal) > 0.1f)
            {
                stateManager.SelectState(stateManager.runState);
            }
            else
            {
                stateManager.SelectState(stateManager.idleState);
            }
        }
    }
}
