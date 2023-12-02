using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using Vector3 = UnityEngine.Vector3;

public class FPSInputscript : MonoBehaviour
{
    private float speed = 6.0f;
    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        // access a component attached to the object
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // W-A-S-D Controls
        float dx = Input.GetAxis("Horizontal") * speed; // keyboard mapping for A-D
        float dz = Input.GetAxis("Vertical") * speed; // keyboard mapping for W-S

        Vector3 movement = new Vector3(dx * Time.deltaTime, 0, dz * Time.deltaTime);

        // limit movement to speed (otherwise diagonal movement with be faster)
        movement = Vector3.ClampMagnitude(movement, speed);

        // transform movement from local to global coordinate system
        movement = transform.TransformDirection(movement);

        // Time.deltaTime return the time needed to render the last frame
        // used to make movement framerate independent()
        cc.Move(movement);

    }
}
