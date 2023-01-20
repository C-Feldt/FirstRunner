using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpHeight = 2f;

    private CharacterController characterController;
    private float gravity = -50f;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontalInput;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        horizontalInput = 1;

        // Face Forward
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        // Sets isGrounded
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);
        
        // Reset or Add gravity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Vertical Velocity
        characterController.Move(velocity * Time.deltaTime);
    }
}
