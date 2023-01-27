using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterController : MonoBehaviour
{
    //Serialized variables
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private Transform[] wallChecks;

    // Public/Global variables
    public string gameState = "Playing";
    // List of current gameStates: StartMenu, Playing, GameOver, Victory

    //Private variables
    public CharacterController characterController;
    private float gravity = -50f;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isBlocked;
    private float horizontalInput;
    private Animator animator;
    private bool jumpPressed;
    private float jumpTimer;
    private float jumpGracePeriod = 0.2f;
    private AudioSource jumpSoundEffect;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        jumpSoundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {

        if(gameState == "Playing")
        {
            horizontalInput = 1;
        }
        else if (gameState == "GameOver")
        {
            horizontalInput = -0.3f;
        }
        else if (gameState == "Victory")
        {
            horizontalInput = 0;
        }
        else if (gameState == "StartMenu")
        {
            horizontalInput = 0;
        }
        else
        {
            horizontalInput = 0;
        }

        // Face Forward
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        // GroundCheck: checks for whether the player is on the ground
        isGrounded = false;
        foreach (var groundCheck in groundChecks)
        {
            if(Physics.CheckSphere(groundCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                isGrounded = true;
                break;
            }
        }
        
        // Reset or Add gravity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Wallcheck: checks for whether the player has run into a wall
        isBlocked = false;
        foreach (var wallCheck in wallChecks)
        {
            if(Physics.CheckSphere(wallCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                isBlocked = true;
                break;
            }
        }

        // Moves character forward if not blocked
        if(!isBlocked)
        {
        characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);    
        }

        // Jump
        jumpPressed = Input.GetButtonDown("Jump");

        if(jumpPressed)
        {
            jumpTimer = Time.time;
        }

        if(isGrounded && (jumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod)))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            if(jumpSoundEffect != null)
            {
                jumpSoundEffect.Play();
            }
            jumpTimer = -1;
        }

        if(transform.position.y < -5)
        {
            gameState = "GameOver";
        }


        // Vertical Velocity
        characterController.Move(velocity * Time.deltaTime);

        // Run Animator Speed
        animator.SetFloat("Speed", horizontalInput);

        // Set Animator IsGrounded
        animator.SetBool("IsGrounded", isGrounded);

        // Set Animator VerticalSpeed (for Blend Tree)
        animator.SetFloat("VerticalSpeed", velocity.y);
    }
}
