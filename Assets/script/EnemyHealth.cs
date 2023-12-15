using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{

    private Animator animator;

    int health;
    public int maxHealth = 100;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame

    public void EnemyTakeDamage()
    {
        health -= damage;
 

        if (health <= 0)
        {
            Die();
            animator.SetTrigger("Death");
        }
    }
    void Die()
    {

        Debug.Log("Enemy died");
        this.enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<EnemySpider>().enabled = false;

        //die animation
    }
}

