using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public float jumpForce;
    public Rigidbody2D rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 6;
        jumpForce = 6;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            this.transform.Translate(-moveSpeed * Time.deltaTime,0,0);
            animator.SetBool("Walk", true);
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            this.transform.Translate(moveSpeed * Time.deltaTime,0,0);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    void JumpPlater()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);
        }
    }
}
