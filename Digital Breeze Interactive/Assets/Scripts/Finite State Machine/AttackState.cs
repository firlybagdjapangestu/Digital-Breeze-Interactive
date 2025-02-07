using UnityEngine;

public class AttackState : NinjaState
{
    public AnimationClip anim;
    public float attackDamage = 10f;
    public float attackRange = 1f;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public override void OnEnableState()
    {
        if(stateManager.isGrounded && stateManager.horizontal == 0)
        {
            stateManager.animator.Play(anim.name);
        } 
    }

    public override void UpdateState()
    {
        // Check if the animation has finished playing
        if (stateManager.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            stateManager.SelectState(stateManager.idleState);
        }
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
        }
    }

    public void EndAttack()
    {
        stateManager.animator.SetBool("isAttacking", false);
    }
}
