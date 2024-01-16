using UnityEngine;

namespace EthanTheHero
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float jumpForce = 10f;
        public float wallSlidingSpeedMax = 1f;
        public Transform groundCheck;
        public Transform wallCheck;
        public float checkRadius = 0.2f;
        public LayerMask groundLayer;
        public LayerMask wallLayer;
        public int extraJumpValue = 1;

        private Rigidbody2D rb;
        private float moveInput;
        private bool isFacingRight = true;
        private bool isGrounded;
        private bool isTouchingWall;
        private bool isWallSliding;
        private int extraJumps;
        public float wallJumpTime = 0.2f;
        private float jumpTime;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            extraJumps = extraJumpValue;
        }

        void Update()
        {
            HandleInput();
        }

        void FixedUpdate()
        {
            CheckSurroundings();
            HandleMovement();
            HandleWallSliding();
        }

        private void HandleInput()
        {
            moveInput = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                HandleJump();
            }
        }
        private void HandleMovement()
        {
            if (!isWallSliding)
            {
                moveInput = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

                if ((isFacingRight && moveInput < 0) || (!isFacingRight && moveInput > 0))
                {
                    Flip();
                }
            }
        }

        private void CheckSurroundings()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer) ||
                         Physics2D.OverlapCircle(groundCheck.position, checkRadius, wallLayer);

            isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, wallLayer) ||
                             Physics2D.OverlapCircle(wallCheck.position, checkRadius, groundLayer);
        }

        private void HandleJump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded || isWallSliding)
                {
                    // Perform a jump
                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps = extraJumpValue;
                    isWallSliding = false; // Exiting wall slide state if applicable
                }
                else if (extraJumps > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;
                }
            }
        }

        private void HandleWallSliding()
        {
            if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
            {
                isWallSliding = true;
                jumpTime = Time.time + wallJumpTime;
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeedMax, float.MaxValue));
            }
            else if (jumpTime < Time.time)
            {
                isWallSliding = false;
            }
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
        }
    }
}