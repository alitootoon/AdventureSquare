using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaverCombat : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAttack();
        }


    }
    void PlayerAttack()
    {
        animator.SetTrigger("Attack");
    }
}
