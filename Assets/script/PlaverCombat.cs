using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaverCombat : MonoBehaviour
{
    public Animator animator;
    public GameObject AttackPoint;

    public LayerMask enemyLayers;

    public int weponDamage = 10;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    float attackTime = 0f;
    

   

    void Update()
    {
        if (Time.time >= attackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayerAttack();
                attackTime = Time.time + 1f / attackRate;
            }

        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("Blocking");
        }


    }

   

    void PlayerAttack()
    {
        animator.SetTrigger("Attack");

        Collider[] hitEnemy = Physics.OverlapSphere(AttackPoint.transform.position, attackRange, enemyLayers);


        foreach (Collider enemy in hitEnemy)
        {
            Debug.Log("enemy hit");
            enemy.GetComponent<EnemyHealth>().EnemyTakeDamage();
        }

    }
    private void OnDrawGizmosSelected()
    {

        if (AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.transform.position, attackRange);
    }

    

}
