using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    private Animator _animator;
    private float rotationSpeed = 360.0f;
    private Quaternion defaultRotation; // Default forward rotation

    void Start()
    {
        _animator = GetComponent<Animator>();
        //_animator.SetFloat("Speed", 0.0f);
        defaultRotation = transform.rotation; // Set the default forward rotation
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        // Update the animator's Running state
        bool isRunning = horizontal != 0 || vertical != 0;
        _animator.SetBool("Walking", isRunning);

        // Jump
        if (Input.GetKeyDown("space"))
        {
            //_animator.SetBool("Jumping", true);
            _animator.SetTrigger("Jumping");
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_animator.IsInTransition(0))
            _animator.SetBool("Jumping", false);

        // Roll
        if (Input.GetKeyDown("r"))
        {
            _animator.SetBool("Rolling", true);
        }
        if (Input.GetKeyUp("r"))
        {
            _animator.SetBool("Rolling", false);
        }

        //// Rotate character or reset to default rotation
        //if (direction != Vector3.zero)
        //{
        //    // Rotate character towards movement direction
        //    Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    // Reset character to default rotation when idle
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, defaultRotation, rotationSpeed * Time.deltaTime);
        //}
    }
}