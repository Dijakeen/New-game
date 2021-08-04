using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform hookStart;
    [SerializeField] Transform playerBody,pointer;   
    [SerializeField] float sensativity = 100f;
    private SpringJoint joint;
    private Vector3 grapplePoint,PoinerReference;
    [SerializeField] float maxDistance = 1000;
    LineRenderer lr;

    float xRotation;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Start()
    {       
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        GraplingHook();

        CameraRotation();
    }

    private void LateUpdate()
    {
        pointer.position = PoinerReference;
        DrawLine();
    }

    private void DrawLine()
    {
        if (!joint) return;
        lr.SetPosition(index: 0, hookStart.position);
        lr.SetPosition(index: 1, grapplePoint);
    }

    private void GraplingHook()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawLine(transform.position, transform.forward * 100, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            PoinerReference = hit.point;
            if (Input.GetMouseButtonDown(0))
            {
                joint = playerBody.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                grapplePoint = hit.point;
                joint.connectedAnchor = grapplePoint;
                joint.spring = 4.5f;
                joint.damper = 7f;
                joint.massScale = 4.5f;
                lr.positionCount = 2;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            lr.positionCount = 0;
            Destroy(joint);
            
        }
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensativity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensativity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
