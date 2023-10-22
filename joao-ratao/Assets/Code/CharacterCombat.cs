using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    //define animator
    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;
    public int damage = 5;

    public float attackSpeed = 2f;
    float attackCooldown = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && attackCooldown <= Time.time)
        {
            Attack();
            attackCooldown = Time.time + 1f / attackSpeed;
        }
    }

    void Attack()
    {
        attackPoint.gameObject.GetComponentInChildren<Animator>().SetTrigger("Slash");

        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in enemiesHit)
        {
            if (enemy.enabled)
            {
                enemy.GetComponent<BossHealth>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
