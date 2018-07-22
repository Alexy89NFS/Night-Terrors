using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float speed = 6.0f;
    public float sprintSpeed = 8.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;

    float cruisingSpeed;
    bool isSprinting;

    public void Start()
    {
        cruisingSpeed = speed;
    }

    void Update()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            cruisingSpeed = sprintSpeed;
            isSprinting = true;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            cruisingSpeed = speed;
            isSprinting = false;
        }

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= cruisingSpeed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
