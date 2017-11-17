using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlaform : MonoBehaviour {


    public enum Direction { Forward, Backward, Up, Down , Left, Right}

    public Direction dir;
    public float speed = 0.5f;

    Vector3 startingPos;
    Vector3 endingPos;
    float percentage = 0.0f;
    float travelDistance = 10.0f;

    bool towardsEnd = true;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;

        Vector3 direction = Vector3.zero;
        switch (dir)
        {
            case Direction.Forward:
                direction = transform.forward;
                break;
            case Direction.Backward:
                direction = -transform.forward;
                break;
            case Direction.Up:
                direction = transform.up;
                break;
            case Direction.Down:
                direction = -transform.up;
                break;
            case Direction.Left:
                direction = -transform.right;
                break;
            case Direction.Right:
                direction = transform.right;
                break;

        }



        endingPos = startingPos + direction * travelDistance;
		
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
