using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Interaction
    [SerializeField] Input Mouse;
    Vector2 mousePositionInput;
    Camera myCamera;
    [SerializeField] Input INTERACTION;
    [SerializeField] LayerMask interactionLayer;


    //movement
    public float speed;
    public float jumpForce;
    private float moveInput;

    //animator
    public Animator animator;

    private Rigidbody2D rb;

    private bool facingRight = true;

    //ground
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //extra jump
    public int extrajumps;
    public int extrajumpsValue;

    //dash2

    [Header("Dashing")]
    public bool canDash = true;
    public float dashingTime;
    public float dashSpeed;
    public float dashJumpIncrease;
    public float timeBTWDashes;

    [Header("Events")]
    [Space]

    //wall climb
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallsliding;
    public float wallSlidingSpeed;

    //wall jump
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;


    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }


    void Start()
    {
        extrajumps = extrajumpsValue;
        rb = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        
        

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            if (!startCutscene.isCutsceneOn && !Dialog.isDialogOn)
            {
                moveInput = Input.GetAxis("Horizontal");
            }
            else if (startCutscene.isCutsceneOn || Dialog.isDialogOn)
            {
                moveInput = 0;
                //speed = 0;
                animator.SetFloat("Speed", 0);
            }


        //Debug.Log(moveInput);
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);



            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }

            if (isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    DashAbility();
                }
            }
        
    }


    private void Update()
    {
        if (!startCutscene.isCutsceneOn && !Dialog.isDialogOn)
        {
            if (isGrounded == true)
            {
                extrajumps = 1;
            }
            if (Input.GetKeyDown(KeyCode.Space) && extrajumps > 0)
            {
                //animator.ResetTrigger("Idle");
                animator.SetTrigger("Jump");
                rb.velocity = Vector2.up * jumpForce;
                extrajumps--;

            }
            else if (Input.GetKeyDown(KeyCode.Space) && extrajumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }

            isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

            if (isTouchingFront == true && isGrounded == false && moveInput != 0)
            {
                wallsliding = true;
            }
            else
            {
                wallsliding = false;
            }
            if (wallsliding)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            }
            if (Input.GetKeyDown(KeyCode.Space) && wallsliding == true)
            {
                wallJumping = true;
                Invoke("SetWallJumpingToFalse", wallJumpTime);
            }
            if (wallJumping == true)
            {
                rb.velocity = new Vector2(xWallForce * -moveInput, yWallForce);
            }

            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }
            if (startCutscene.isCutsceneOn || Dialog.isDialogOn)
            {
                moveInput = 0;
                //speed = 0;
                animator.SetFloat("Speed", 0);
            }
        
    }

        public void OnLanding()
        {
            animator.SetBool("isJumping", false);
        }
        
        public void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }

        void Flip()
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }
        
        void DashAbility()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
        IEnumerator Dash()
        {
            canDash = false;
            speed = dashSpeed;
            jumpForce = dashJumpIncrease;
            yield return new WaitForSeconds(dashingTime);
            speed = 11;
            jumpForce = 16;
            yield return new WaitForSeconds(timeBTWDashes);
            canDash = true;
        }

    }


}
