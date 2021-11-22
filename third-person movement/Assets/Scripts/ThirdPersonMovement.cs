using UnityEngine;

//   THIS IS FOR THE CHARACTER MOVEMENT AND CAMERA

public class ThirdPersonMovement : MonoBehaviour
{
    // Drags the CC and TF, into the slot.
    public CharacterController controller;
    public Transform cam;

    //ANIMATION
    public Animator anim; // Getting the animator

    public float normalSpeed = 15f; // Normal walk speed
    public float jumpHeight = 3f; // Jumpheight.
    public float speed = 6f; // Movement Speed.
    // Sprinting.
    public bool isSprinting = false;
    public float sprintingSpeed = 20f;

    // Crouching.
    public bool isCrouching = false;
    public float CrouchingSpeed = 5f;


    // Gravity for the player
    public float gravity = -9.81f;

    public float TurnSmoothTime = 0.1f; // For Smooth turning
    float turnSmoothVelocity;

    // GROUNDCHECK
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity; // I don't remember. ; U ; 

    // Check if it's Grounded
    bool isGrounded;


    //COMBAT
    public bool isAttacking;



    // Update is called once per frame
    void Update() // ;W; THere's so much.
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Stores direction of the horizontal and vertical.
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // Normalized is so the speed will still be normal even tho you press 2 keys the same time.


        //CAMERA
        if (direction.magnitude >= 0.1f)
        {

            // THE MOVEMENT
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // JUMPING
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            anim.SetTrigger("Jump");
        }

        // SPRINTING
        if (Input.GetKey(KeyCode.LeftShift))//Checks if shift botton is pressed.
        {
            isSprinting = true;
            speed = sprintingSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
            speed = CrouchingSpeed;
        }
        else
        {
            isSprinting = false; isCrouching = false;
            speed = normalSpeed;

        }

        //Velocity for gravity.
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //ANIMATION CONTROLLER.
        anim.SetBool("isGrounded", isGrounded); // The JUMPING ANIAMATION.
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            anim.SetBool("jumping", true);
        }
        else {
            anim.SetBool("jumping", false); //
        }
        // WALKING ANIMATION
        if (horizontal != 0 || vertical != 0) // I the horizontal or vertical movement is not 0 it triggers the animation
        {
            anim.SetBool("walking", true);
        }
        else {
            anim.SetBool("walking", false);
        } // The other way, to do it with a shorter code. 
          //anim.SetBool("walking", horizontal != 0 || vertical != 0);

        // Sprinting animation.
        if (speed == sprintingSpeed)
        {
            anim.SetBool("IsSprinting", true);
        }
        else
        {
            anim.SetBool("IsSprinting", false);
        }
        // Crouching animation 
        if (speed == CrouchingSpeed)
        {
            anim.SetBool("IsCrouching", true);
        } else
        {
            anim.SetBool("IsCrouching", false);
        }

        //Punching
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("IsPunching");
        }
    }
}
