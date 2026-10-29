using NUnit.Framework.Constraints;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public float jumpForce;
    public bool isGrounded;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 6;
        isGrounded = true;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpPlayer();
    }

    void MovePlayer()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            this.transform.Translate(-moveSpeed * Time.deltaTime,0,0);
            animator.SetBool("Walk", true);
            spriteRenderer.flipX = true;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            this.transform.Translate(moveSpeed * Time.deltaTime,0,0);
            animator.SetBool("Walk", true);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    void JumpPlayer()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded == true)
        {
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);
            animator.SetBool("Jump", true);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            animator.SetBool("Jump", false);
            isGrounded = true;
        }
    }
}
