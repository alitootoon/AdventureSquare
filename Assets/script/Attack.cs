using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    Transform player;
    Rigidbody rb;
    public float RunRange = 10f;

    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Vector3.Distance(player.position, rb.position) <= RunRange)
        {
            animator.SetTrigger("Run");
        }

    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player01")
        {
            Debug.Log("Attack!");
            // I set the 'isAttacking' parameter of the Animator Controller to true
            animator.SetBool("isAttacking", true);
        }
    }
    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player01")
        {
            Debug.Log("Stop Attack!");
            // Do something (e.g., stop subtracting HP)
            animator.SetBool("isAttacking", false);
        }
    }
    
}