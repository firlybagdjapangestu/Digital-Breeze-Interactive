using System.Collections;
using UnityEngine;

public class HurtState : NinjaState
{
    public AnimationClip anim;
    public override void EnterState()
    {
        stateManager.animator.Play(anim.name);
        StartCoroutine(StateAnimation());
    }
    public override void UpdateState()
    {
        // Check if the animation has finished playing
        
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

    IEnumerator StateAnimation()
    {
        yield return new WaitForSeconds(anim.length);
        stateManager.SelectState(stateManager.idleState);
    }

}
