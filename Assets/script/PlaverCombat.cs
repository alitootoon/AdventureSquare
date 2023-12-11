using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaverCombat : MonoBehaviour
{
    public Animator animator;
    public int weponDamage = 10;
    public LayerMask enemyLayers;
    public GameObject AttackPoint;
    public float attackRange = 0.5f;
    // Start is called before the first frame update

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAttack();
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
