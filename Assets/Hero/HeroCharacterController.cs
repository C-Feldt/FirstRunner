using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterController : MonoBehaviour
{
    //Serialized variables
    [SerializeField] private LayerMask groundLayers;    // The "ground" layers the Hero collides with
    [SerializeField] private float runSpeed = 8f;       // Hero's run speed
    [SerializeField] private float jumpHeight = 2f;     // Hero's jump height (NOT jump duration)
    [SerializeField] private Transform[] groundChecks;  // position that check's the Hero's bottom sides for the ground
    [SerializeField] private Transform[] wallChecks;    // position that check's the Hero's sides for the walls

    // Public/Global variables
    public string gameState = "Playing";
    // List of current gameStates: StartMenu, Playing, GameOver, Victory

    //Private variables
    public CharacterController characterController; // Hero's character controller
    private float gravity = -50f;                   // Strength of gravity on the Hero
    private Vector3 velocity;                       // Velocity of the hero    
    private bool isGrounded;                        // Status of whether the Hero is grounded
    private bool isBlocked;                         // Status of whether the Hero is being blocked
    private float horizontalInput;                  // Hero's horizontal movement speed (run/walk/etc)
    private Animator animator;                      // Animation manager for the Hero
    private bool jumpPressed;                       // Status of whether a jump has been queued (for jump buffer)
    private float jumpTimer;                        // Amount of time jump will remain loaded
    private float jumpGracePeriod = 0.2f;           // Amount of time jumps stay loaded
    private AudioSource jumpSoundEffect;            // Sound effect for the jump


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        jumpSoundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {

        // Player's movement speed by gameState 
        if(gameState == "Playing")
        {
            horizontalInput = 1;
        }
        else
        {
            horizontalInput = 0;
        }

        // Set Hero to face forward while running
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

        // Stores Jump input
        jumpPressed = Input.GetButtonDown("Jump");

        // Begins jump timer, and changes gameState if on Instructions screen
        if(jumpPressed)
        {
            jumpTimer = Time.time;
            if(gameState == "Instructions")
            {
                gameState = "Playing";
            }
        }

        // Jump buffer for smoother gameplay; stores a jump input for short amount of time while in air
        if(isGrounded && (jumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod)))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            if(jumpSoundEffect != null)
            {
                jumpSoundEffect.Play();
            }
            jumpTimer = -1;
        }

        // Ends game if player falls below certain height (off-screen)
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
