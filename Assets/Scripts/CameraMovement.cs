using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private float maxZoom = 10f;
    [SerializeField] private float minZoom = 1f;

    private Vector3 prevPosition;
    private Vector3 currPosition;
    public Transform target;
    public GameObject currPlanet;
    
    float closeRange;
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            target = hit.collider.transform;
            currPlanet = target.gameObject;
        }

        currPosition = cam.ScreenToViewportPoint(Input.mousePosition);

        closeRange = Mathf.Sqrt(
                Mathf.Pow(Mathf.Abs(cam.transform.position.x - target.transform.position.x), 2) +
                Mathf.Pow(Mathf.Abs(cam.transform.position.y - target.transform.position.y), 2) +
                Mathf.Pow(Mathf.Abs(cam.transform.position.z - target.transform.position.z), 2)
                );

        cam.transform.position = target.position;

        if (Input.GetMouseButtonDown(0))
        {
            prevPosition = currPosition;

        }
      
            Vector3 direction = prevPosition - currPosition;
        if (Input.GetMouseButton(0))
        {
            cam.transform.position = target.position; 

            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
        }
            cam.transform.Translate(new Vector3(0, 0, -closeRange));
            prevPosition = currPosition;
        

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && closeRange >= maxZoom)
        {
            cam.transform.Translate(new Vector3(0, 0, scrollSpeed));
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && closeRange <= minZoom)
        {
            cam.transform.Translate(new Vector3(0, 0, -scrollSpeed));
        }
    }
}
