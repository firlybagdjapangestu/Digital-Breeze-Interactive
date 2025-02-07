using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : NinjaState
{
    public AnimationClip anim;
    public override void OnEnableState()
    {
        stateManager.animator.Play(anim.name);
    }

    public override void UpdateState()
    {
        if (!stateManager.isGrounded || stateManager.horizontal != 0)
        {
            stateManager.SelectState(stateManager.runState);
        }
    }

}
