using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlaform : MonoBehaviour {


    Vector3 startingPos;
    Vector3 endingPos;
    float percentage = 0.0f;
    float speed = 0.5f;

    float travelDistance = 10.0f;

    bool towardsEnd = true;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
        endingPos = startingPos + transform.forward * travelDistance;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (percentage < 1.0f)        
            percentage += Time.deltaTime * speed;        
        else
        {
            towardsEnd = !towardsEnd;
            percentage = 0.0f;
        }



        if(towardsEnd)
            transform.position = Vector3.Lerp(startingPos, endingPos, percentage);        
        else
            transform.position = Vector3.Lerp(endingPos, startingPos, percentage);



    }

   
}
