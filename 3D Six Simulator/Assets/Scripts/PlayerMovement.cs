using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 12;

    Rigidbody rigidBody;
    float moveX;
    float moveZ;


    bool isTouching = false;
    public float jumpPower;

    public Transform _camera;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();

        if (rigidBody == null)
            Debug.LogError("RigidBody could not be found.");
    }


    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

    }

    void FixedUpdate()
    {

        Vector3 cameraDirection = transform.position - _camera.position; //direction to move in is equal to the Vector3 between camera and player (direction camera is facing)
        cameraDirection.y = 0.0f; //zeros the vertical aspect of movement direction to stay in the x-z plane
        if (rigidBody != null)
        {
            rigidBody.AddForce(cameraDirection * moveSpeed, ForceMode.Acceleration);
        }
        if (isTouching && Input.GetKeyDown("space"))
        { //jump
            rigidBody.AddForce(new Vector3(0, jumpPower, 0) * 50, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isTouching = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isTouching = false;
    }

}
