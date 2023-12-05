using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonWalk : MonoBehaviour
{
    public float speed;
    public float distanceToPlayer = 1.5f;
    private float distancef;
    public Transform target;
    public Rigidbody rb;
    Animator animator;


    // Start is called before the first frame update
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void followPlayer()
    {
 
        if (target.parent.tag == "Player01")
        {
            Vector3Distance distance = new Vector3Distance(); 
            distancef = distance.Operation(transform.position, target.position);
            Debug.Log(distancef.ToString());
            if (distancef <= distanceToPlayer)
            {
                animator.SetBool("seesPlayer", false);
                animator.SetBool("CouldHit", true);
                                
            }
            else
            {
                animator.SetBool("CouldHit", false);
                animator.SetBool("seesPlayer", true);
                //Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                //rb.MovePosition(pos);
                transform.LookAt(target);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player01")
        {
            animator.SetBool("seesPlayer", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player01")
        {
            animator.SetBool("seesPlayer", false);
            rb.MovePosition(transform.position);
            transform.LookAt(target);           

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player01")
            followPlayer();
    }
}
