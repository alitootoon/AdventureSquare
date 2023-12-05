using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerSkeleton : MonoBehaviour
{
    public Healthbar healthbar;
    public int damage = 2;
    public Animator animator1;
    // Start is called before the first frame update
    void Start()
    {
        //animator1 = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("HIT ME");

        if (collider.gameObject.tag == "Player01")
        {
            if (animator1.GetBool("CouldHit"))
            {
                healthbar.takeDamage(damage);
            }
        }

        
    }

   

}