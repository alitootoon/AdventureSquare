using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _animatorS2;

    // Start is called before the first frame update
    void Start()
    {
        _animatorS2 = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player01")
        {
            Debug.Log("Attack!");
            // I set the 'isAttacking' parameter of the Animator Controller to true
            _animatorS2.SetBool("isAttacking", true);
        }
    }
    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player01")
        {
            Debug.Log("Stop Attack!");
            // Do something (e.g., stop subtracting HP)
            _animatorS2.SetBool("isAttacking", false);
        }
    }
    
}