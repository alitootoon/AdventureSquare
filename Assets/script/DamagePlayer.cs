using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public Healthbar healthbar;
    public int damage = 2;
    private Animator animator1;
    // Start is called before the first frame update
    void Start()
    {
        animator1 = GetComponentInChildren<Animator>();
        //animator1 = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player01")
        {
            if (animator1.GetBool("CouldHit"))
            {
                healthbar.takeDamage(damage);
            }
            
        }
    }


}
