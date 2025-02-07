using UnityEngine;

public class DieState : NinjaState
{
    public AnimationClip anim;

    public override void OnEnableState()
    {
        stateManager.animator.Play(anim.name);
        stateManager.rb.velocity = Vector2.zero;
    }


    public override void UpdateState()
    {

    }

    public override void OnTriggerEnter2DState(Collider2D collider)
    {
        // Handle any specific logic when the ninja is in the die state and collides with something
    }
}
