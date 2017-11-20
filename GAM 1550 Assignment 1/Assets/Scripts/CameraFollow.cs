using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public GameObject followPoint;
    //Vector3 followPos;

   // public GameObject camera;
    public GameObject player;

  //  public float distanceToPlayer;

    public float speed = 100.0f;
    public float distanceToFollow = 10.0f;
    public float clampAngle = 80.0f;

     float mouseX = 0.0f;
     float mouseY = 0.0f;
     float xRot;
     float yRot;
   


   // public float followDistance = 7.0f;
  //  public float percentage;

	// Use this for initialization
	void Start ()
    {
        //Vector3 rotation = transform.localRotation.eulerAngles;
        //xRot = rotation.x;
        //yRot = rotation.y;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        player.transform.Rotate(Vector3.up, mouseX * speed * Time.deltaTime);


        transform.Rotate(-Vector3.right, mouseY * speed * Time.deltaTime);

        //Vector3 newPos = followPoint.transform.position;

       // newPos.x += -mouseX * speed * Time.deltaTime;
       // newPos.y += mouseY * speed * Time.deltaTime;


       // followPoint.transform.position = newPos;


       // Vector3 displacement = player.transform.position - transform.position;

       // Vector3 behindPlayer = -player.transform.forward * distanceToFollow;

       // if(displacement.magnitude > distanceToFollow)
        {
        }



        // xRot += mouseX * speed * Time.deltaTime;
        // yRot += mouseY * speed* Time.deltaTime;

        //xRot = Mathf.Clamp(xRot, -clampAngle, clampAngle);

        //Quaternion rotation = Quaternion.Euler(yRot, -xRot, 180.0f);
        //transform.rotation = rotation;
    }

    // Update is called once per frame
    void LateUpdate () {

        //RaycastHit ray;
        //if(Physics.Raycast(transform.position, -player.transform.forward,out ray,10))
        //{
        //    Vector3 displacement = transform.position - ray.point;

        //    transform.position += displacement.normalized * 2;

        //  //  transform.position += transform.forward * 
        //}

        // UpdateCamera();
      //  transform.LookAt(followPoint.transform);


    }

    void UpdateCamera()
    {
       // float step = speed * Time.deltaTime;
       // transform.position = Vector3.MoveTowards(transform.position, followPoint.transform.position, step);
    }

    private void OnDrawGizmos()
    {
     //   Gizmos.DrawLine(transform.position, -player.transform.forward * 10);
    }

}

