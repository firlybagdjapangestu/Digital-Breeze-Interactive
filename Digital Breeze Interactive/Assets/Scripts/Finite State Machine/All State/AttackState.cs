using System.Collections;
using UnityEngine;

public class AttackState : NinjaState
{
    public AnimationClip anim;
    public int attackDamage = 10;
    public float attackRange = 1f;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public override void EnterState()
    {
        stateManager.animator.Play(anim.name);
        StartCoroutine(StateAnimation());
        Attack();
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            ZombieBehaviour zombie = enemy.GetComponent<ZombieBehaviour>();
            if (zombie != null)
            {
                zombie.hp -= attackDamage;
            }
        }
    }

    IEnumerator StateAnimation()
    {
        yield return new WaitForSeconds(anim.length);
        stateManager.SelectState(stateManager.idleState);
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
