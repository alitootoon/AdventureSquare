using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpider : MonoBehaviour
{

    public float enemyRadios = 10f;
    public Animator animator;
    Transform target;
    NavMeshAgent agent;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask HeroLayers;
    //Vector3 offset = new Vector3(0, 0, -2.5f);

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player01").transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= enemyRadios)
        {
            animator.SetTrigger("Run");
            agent.stoppingDistance = 2f;
            agent.SetDestination(target.position);
            if (distance < agent.stoppingDistance)
            {
                animator.SetBool("isAttacking", true);
                
                DamagePlayer();

            }
        }
        
    }

    void DamagePlayer()
    {
        animator.SetTrigger("Attack");

        Collider[] hitEnemy = Physics.OverlapSphere(AttackPoint.transform.position, attackRange, HeroLayers);


        foreach (Collider enemy in hitEnemy)
        {
            if(animator.GetBool("isAttacking") == true)
            {
                Debug.Log("hero get hit");
            }
            //Debug.Log("hero get hit");
            //enemy.GetComponent<EnemyHealth>().EnemyTakeDamage();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyRadios);
    }
}
