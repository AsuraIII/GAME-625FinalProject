using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunandJump : MonoBehaviour
{
    public float speed = 6;
    Rigidbody2D rb;
    public float jumpForce = 6;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public float rememberGroundedFor;
    float lastTimeGrounded;
    public int defaultAdditionalJumps = 1;
    int additionalJumps;

    public bool canMove = true;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();
        BetterJump();
    }
    void Move()
    {
        if (canMove)
        {
            float x = Input.GetAxisRaw("Horizontal");
            // Debug.Log(x);
            //flip character
            if (x != 0)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = x;
                transform.localScale = theScale;
            }

            float moveBy = x * speed;
            animator.SetFloat("Speed", Mathf.Abs(moveBy));
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        }
    }
    void Jump()
    {
        if (canMove)
        {

            if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
            {
                animator.SetBool("IsJumping", true);
                SoundManager._instance.PlayerJumpSound();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                additionalJumps--;
            }
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        //Debug.Log(colliders);
        if (colliders != null)
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            additionalJumps = defaultAdditionalJumps;
        }
        else
        {
            if (isGrounded)
            {

                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
