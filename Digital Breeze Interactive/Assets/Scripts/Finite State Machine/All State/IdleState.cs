using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : NinjaState
{
    public AnimationClip anim;

    public override void EnterState()
    {
        if(!stateManager.isGrounded && stateManager.horizontal != 0)
            return;
        stateManager.animator.Play(anim.name);
    }


    public override void UpdateState()
    {
        if (stateManager.horizontal != 0)
        {
            stateManager.SelectState(stateManager.runState);
        } 
        else if(!stateManager.isGrounded)
        {
            stateManager.SelectState(stateManager.jumpState);
        }
    }

}
