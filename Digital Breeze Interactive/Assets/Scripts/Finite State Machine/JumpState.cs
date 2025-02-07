using UnityEngine;

public class JumpState : NinjaState
{
    public AnimationClip anim;
    public float jumpForce;

    public override void OnEnableState()
    {
        stateManager.animator.Play(anim.name);
        float animationDuration = anim.length;
        float adjustedJumpForce = jumpForce / animationDuration;
        stateManager.rb.velocity = new Vector2(stateManager.rb.velocity.x, adjustedJumpForce);
    }

    public override void UpdateState()
    {
        if (stateManager.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
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
}
