using UnityEngine;

public class RunState : NinjaState
{
    public AnimationClip anim;
    public float moveSpeed;
    public override void EnterState()
    {
        if (!stateManager.isGrounded && stateManager.horizontal == 0)
            return;
        stateManager.animator.Play(anim.name);
    }

    public override void FixedUpdateState()
    {
        stateManager.rb.velocity = new Vector2(stateManager.horizontal * moveSpeed, stateManager.rb.velocity.y);
        if (stateManager.horizontal == 0)
        {
            stateManager.SelectState(stateManager.idleState);
        }
        else if (!stateManager.isGrounded)
        {
            stateManager.SelectState(stateManager.jumpState);
        }
    }
}
