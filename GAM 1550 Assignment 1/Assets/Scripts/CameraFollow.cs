using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public GameObject target;
    Vector3 displacement;


    float distanceToFollow = 10.0f;
    float mouseX = 0.0f;
    float mouseY = 0.0f;


   // public float followDistance = 7.0f;
  //  public float percentage;

	// Use this for initialization
	void Start () {
        // target = GameObject.FindGameObjectWithTag("Player");
        //target = GameObject.FindGameObjectWithTag("CameraEmpty");

     //   displacement =  transform.position  - target.transform.position ;

    }

    private void Update()
    {
        //mouseX = Input.GetAxis("Mouse X");
        //mouseY = Input.GetAxis("Mouse Y");
    }

    // Update is called once per frame
    void LateUpdate () {

        //Vector3 dir = new Vector3(0, 0, -distanceToFollow);
        //Quaternion rotation = Quaternion.Euler(mouseX, mouseY, 0);

        //transform.position = target.transform.position + rotation * dir;

        //float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        //transform.Rotate(0, mouseX, 0);

        //float desiredAngle = target.transform.eulerAngles.y;
        //Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        //transform.position = target.transform.position - (rotation * displacement);


        //Vector3 desiredPos = target.transform.position + displacement;
        //Vector3 newPos = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime);
        //transform.position = newPos;

        //  transform.position = Vector3.Lerp(FromPos.transform.position, target.transform.position, percentage);

        //Vector3 displacement = target.transform.position - transform.position;
        //if (displacement.magnitude > followDistance)
        //{
        //   transform.position = target.transform.position - displacement.normalized * followDistance;
        //}

        //Debug.Log(displacement.magnitude);


        transform.LookAt(target.transform.position + new Vector3(0,0.5f,0) , Vector3.up);
        ////transform.rotation = target.transform.rotation;


        //transform.position = new Vector3(transform.position.x, 5.0f, transform.position.z);
	}

    
}

