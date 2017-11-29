using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    public GameObject lookAtPoint;
    Vector3 followPos;
    public GameObject player;

    public float lookSpeed = 100.0f;
    float mouseX = 0.0f;
    float mouseY = 0.0f;


    // Use this for initialization
    void Start()
    {
     
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        lookAtPoint.transform.position += new Vector3(0, mouseY * 0.1f, 0);
        float yClamped = Mathf.Clamp(lookAtPoint.transform.position.y, player.transform.position.y - 5, player.transform.position.y + 5);
        Vector3 clampedHeight = new Vector3(lookAtPoint.transform.position.x, yClamped, lookAtPoint.transform.position.z);
        lookAtPoint.transform.position = clampedHeight;


        player.transform.Rotate(Vector3.up, mouseX * lookSpeed * Time.deltaTime);
        transform.Rotate(-Vector3.right, mouseY * lookSpeed * Time.deltaTime);

    }

    // Update is called once per frame
    void LateUpdate()
    {


        // Vector3 rayDirection = transform.position - player.transform.position;  
        //RaycastHit ray;
        //if (Physics.Raycast(player.transform.position, rayDirection.normalized, out ray, rayDirection.magnitude, ~(1 << LayerMask.NameToLayer("Player"))))
        //{
        //    Debug.Log("Hitting Something");
        //    followPos = player.transform.position + rayDirection.normalized * (ray.distance * 0.9f);

        //}
        //else
        followPos = player.transform.position - player.transform.forward * 3.0f + Vector3.up * 2;
        transform.position = Vector3.Lerp(transform.position, followPos, Mathf.SmoothStep(0.0f, 1.0f, Time.deltaTime * 1000));
        transform.LookAt(lookAtPoint.transform);

    }

}

