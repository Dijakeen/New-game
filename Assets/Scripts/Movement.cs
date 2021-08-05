using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{    
    [SerializeField] float speed = 5f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float maxMAXSpeed = 30f;
    [SerializeField] Vector3 gravity;
    Rigidbody rigidbodyComponent;
    [SerializeField] GameManedger gM;

    

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
       
        
    }
    private void Update()
    {
        rigidbodyComponent.velocity += gravity;




        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            maxSpeed = maxMAXSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxSpeed = 10;
        }
    }

    void FixedUpdate()
    {
        
        SpeedLimit();       
    }

    private void SpeedLimit()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (rigidbodyComponent.velocity.x < maxSpeed && rigidbodyComponent.velocity.x > -maxSpeed
              && rigidbodyComponent.velocity.z < maxSpeed && rigidbodyComponent.velocity.z > -maxSpeed)
            {
                float also = Input.GetAxis("Horizontal") * speed;
                rigidbodyComponent.velocity += transform.right * also;
            }
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            if (rigidbodyComponent.velocity.z < maxSpeed && rigidbodyComponent.velocity.z > -maxSpeed
              && rigidbodyComponent.velocity.x < maxSpeed && rigidbodyComponent.velocity.x > -maxSpeed)
            {
                float also = Input.GetAxis("Vertical") * speed;
                rigidbodyComponent.velocity += transform.forward * also;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Respawn")
        {
            gM.RestartLvl();
        }
    }
}
