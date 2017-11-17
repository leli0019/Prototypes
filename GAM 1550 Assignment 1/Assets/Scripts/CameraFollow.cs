using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public GameObject followPoint;
    Vector3 followPos;

    public GameObject camera;
    public GameObject player;

    Vector3 distanceToPlayer;

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
        Vector3 rotation = transform.localRotation.eulerAngles;
        xRot = rotation.x;
        yRot = rotation.y;
       
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");


         xRot += mouseX * speed * Time.deltaTime;
         yRot += mouseY * speed* Time.deltaTime;

        xRot = Mathf.Clamp(xRot, -clampAngle, clampAngle);

        Quaternion rotation = Quaternion.Euler(yRot, -xRot, 180.0f);
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void LateUpdate () {
        UpdateCamera();

	}

    void UpdateCamera()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, followPoint.transform.position, step);
    }

    
}

