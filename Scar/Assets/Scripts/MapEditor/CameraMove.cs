using System;
using UnityEngine;
using UnityEngine.UI;


public class CameraMove : MonoBehaviour
{
    [SerializeField] private  float cameraSpeed;
    [SerializeField] private float zoomSpeed;
    private Vector3 lastDirectionIntent;

    public ManagerScript ms;

    private float xAxis;
    private float yAxis;
    private float zoom;
    private Camera cam;

    
    //Movement FROM PlayerController.cs
    private void CameraMovement()
    {
        // Get key down (Z,Q,S,D) 
        if (Input.GetKey(KeyCode.D))
        {
            lastDirectionIntent += Vector3.right;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            lastDirectionIntent +=  Vector3.left;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            lastDirectionIntent +=  Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            lastDirectionIntent +=  Vector3.back;
        }
        if (!Input.anyKey)
        {
            // Si on lâche la touche on s'arrête
            lastDirectionIntent = Vector3.zero;
        }
    }

    private void CameraZoom()
    {
        zoom = Input.GetAxis("Mouse ScrollWheel");
        transform.LookAt(cam.transform);
        transform.Translate(0, 0, zoom * zoomSpeed, Space.Self);
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>(); // get the camera component for later use
    }

    private void FixedUpdate()
    {
        cam.transform.position += lastDirectionIntent * (Time.deltaTime * cameraSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (ms.saveLoadMenuOpen == false) // if no save or load menus are open.
        {
            CameraMovement();
            CameraZoom();
        }
        lastDirectionIntent = lastDirectionIntent.normalized;
    }
}