using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float MovementSpeed;
    public float RotateSpeed;
    public float JumpSpeed;

    Rigidbody rig;
    public Transform footPos;
     Vector3 startingPos;

    bool isInAir = false;
    bool isOnPlatform = false;

    int deathCount = 0;

    public Text deathText;


    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
        //transform.position = startingPos.position;
        rig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        //Extra Gravity
        rig.AddForce(-transform.up * 7.0f, ForceMode.Force);

        if (isInAir && transform.parent != null)
            transform.SetParent(null);

        HandleInput();
        HandleGroundCollision();
      //  HandleInAir();


    }

    void HandleInput()
    {

        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * MovementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            transform.position += -transform.forward * MovementSpeed * Time.deltaTime;


        if (Input.GetKey(KeyCode.A))
            transform.Rotate(transform.up, -RotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(transform.up, RotateSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isInAir == false)
            rig.AddForce(transform.up * JumpSpeed, ForceMode.Impulse);


    }

    void HandleGroundCollision()
    {
        RaycastHit info;
        if (Physics.Raycast(footPos.position, -Vector3.up, out info, 0.5f, 1 << LayerMask.NameToLayer("Platform") | 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.Collide))
        {
            if (isOnPlatform == false && info.transform.tag == "Platform")
                transform.SetParent(info.transform);

            if (info.transform.tag == "DeathPit")
                Kill();


            if (isInAir)
                isInAir = false;
        }
        else
        {
            if (isInAir == false)
                isInAir = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        
        if(collision.gameObject.tag == "Crusher" && collision.contacts[0].normal == Vector3.down)
        {
            Debug.Log(collision.contacts[0].normal);
            Kill();
        }
    }


    void Kill()
    {
        transform.position = startingPos;
        deathCount++;

        deathText.text = "Death Count: " + deathCount;
    }


}
