using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Healthbar playerHealth;
    public int damage = 2;
    private Animator _animatorS2;

    // Start is called before the first frame update
    void Start()
    {
        _animatorS2 = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
       
        if (collision.gameObject.tag == "Player")
        {
            if (_animatorS2.GetBool("isAttacking") == true)
            {
                playerHealth.takeDamage(damage);
            }
        }
        StartCoroutine(WaitForFunction());        
    }

    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(1);
    }
}
