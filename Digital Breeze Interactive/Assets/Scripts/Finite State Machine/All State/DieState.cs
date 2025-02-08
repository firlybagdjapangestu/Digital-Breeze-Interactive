using UnityEngine;
using System.Collections;

public class DieState : NinjaState
{
    public AnimationClip anim;

    public override void EnterState()
    {
        stateManager.animator.Play(anim.name);
        stateManager.isDead = true;
        stateManager.rb.velocity = Vector2.zero;
        StartCoroutine(StateAnimation());
        StopGame();
    }

    IEnumerator StateAnimation()
    {
        yield return new WaitForSeconds(anim.length);
    }

    private void StopGame()
    {
        Time.timeScale = 0f;
    }
}
