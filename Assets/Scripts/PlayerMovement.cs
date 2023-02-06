using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private float speed = 20f;
    private float sprintMult = 1;
    private float gravity = -9.7f;
    private float jumpHeight = 7f;

    private bool isGrounded;

    Vector3 velocity;

        private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isGrounded = controller.isGrounded;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * sprintMult * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintMult = 1.7f;
        }
        else
        {
            sprintMult = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("FUCK");
            velocity.y += jumpHeight;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
