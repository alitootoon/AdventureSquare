using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool playerInRange = false;
    public float rotationSpeed = 90.0f; // Degrees per second
    public Vector3 openRotation = new Vector3(0, 90, 0); // The rotation when the door is open
    private bool isDoorOpen = false;

    void Update()
    {
        // Check if the player is in range and the 'E' key is pressed
        if (playerInRange && !isDoorOpen && Input.GetKeyDown("e"))
        {
            Debug.Log("Door is Open!");
            StartCoroutine(RotateDoor(openRotation));
            isDoorOpen = true;
        }
    }

    private IEnumerator RotateDoor(Vector3 toRotation)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(toRotation);
        float t = 0.0f;

        while (t < 1.0f)
        {
            t += Time.deltaTime * rotationSpeed / 360.0f;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }
    }

    // Detect player collision
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player01")) // Make sure your player GameObject has the tag "Player"
        {
            Debug.Log("OpentheDoor!");

            playerInRange = true;
        }
    }

    // Detect when the player leaves the collision area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player01"))
        {
            Debug.Log("ClosetheDoor!");

            playerInRange = false;
        }
    }
}
