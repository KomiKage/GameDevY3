using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private float speed = 12f;
    private float gravity = -9.81f;
    private float jumpHeight = 6f;
    private float sprintMult = 1f;

    public Slider staminaBar;
    public float stamina = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public ParticleSystem floatie;

    Vector3 velocity;
    bool isGrounded;
    bool hovering = false;
    float hoverCost = 0.1f;

    public FPSShooter fps;

    private void Start()
    {
        InvokeRepeating("StaminaLoss", 0.25f, 0.25f);
    }

    private void Update()
    {
        if (stamina > 1) { stamina = 1; }
        staminaBar.value = stamina;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //isGrounded = controller.isGrounded;

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * sprintMult * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded && stamina >= 0.05f)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            stamina = stamina - 0.05f;
        }

        if(Input.GetKey(KeyCode.Space) && !isGrounded && velocity.y < 1f && velocity.y > -1f && fps.mana >= hoverCost)
        {
            hovering = true;
            floatie.Play();
            velocity.y = -0.7f;
        } else { hovering = false; floatie.Pause(); floatie.Clear(); }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintMult = 1.7f;
        }
        else
        {
            sprintMult = 1f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void StaminaLoss()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stamina = stamina - 0.01f;
        }
        else { stamina = stamina + 0.05f; }

        if(hovering == true)
        {
            fps.mana = fps.mana - hoverCost;
        }
    }
}
