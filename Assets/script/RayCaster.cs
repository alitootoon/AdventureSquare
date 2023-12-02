//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Net;
//using System.Numerics;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.Device;
//using Vector3 = UnityEngine.Vector3;

//public class RayCaster : MonoBehaviour
//{
//    private Camera _camera;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // get camera component
//        _camera = GetComponent<Camera>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // check if left mouse (=0) button is down
//        if (Input.GetMouseButtonDown(0))
//        {
//            // get position in middle of the screen
//            Vector3 midPoint = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2);
//            // create ray passing the middle of the screen
//            Ray ray = _camera.ScreenPointToRay(midPoint);

//            // check if object is hit
//            RaycastHit hit;
//            if (Physics.Raycast(ray, out hit))
//            {
//                StartCoroutine(HitIndicator(hit.point));
//            }
//        }
//    }
//    private IEnumerator HitIndicator(Vector3 hitLocation)
//    {
//        // create a sphere and place it where the ray hit on object
//        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//        sphere.transform.position = hitLocation;

//        yield return new WaitForSeconds(1.0f);

//        Destroy(sphere);
//    }
//}