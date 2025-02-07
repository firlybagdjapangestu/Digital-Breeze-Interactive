using UnityEngine;

public class HurtState : NinjaState
{
    public AnimationClip anim;
    public override void OnEnableState()
    {
        stateManager.animator.Play(anim.name);
    }
    public override void UpdateState()
    {
        // Check if the animation has finished playing
        if (stateManager.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            stateManager.SelectState(stateManager.idleState);
        }
        if (stateManager.hp <= 0)
        {
            stateManager.SelectState(stateManager.dieState);
        }
    }
    public override void OnTriggerEnter2DState(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            stateManager.hp -= 10;
            stateManager.animator.Play(anim.name);
        }
    }

}
