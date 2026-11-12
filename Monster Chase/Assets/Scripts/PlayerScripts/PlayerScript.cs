using NUnit.Framework.Constraints;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public float jumpForce;
    public bool isGrounded;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public int lives;
    public TMP_Text lives_tmp;
    public TMP_Text scores_tmp;
    public GameObject bulletObject;
    public bool isBulletOnScreen;
    public int scores;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 6;
        isGrounded = true;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lives_tmp.SetText("Lives: {0}", lives);
        scores_tmp.SetText("Score: {0}", scores);
        isBulletOnScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpPlayer();
        shootBullet();
        if (lives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void MovePlayer()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            this.transform.Translate(-moveSpeed * Time.deltaTime,0,0);
            animator.SetBool("Walk", true);
            spriteRenderer.flipX = true;
        }
        else if (Keyboard.current.dKey.isPressed)
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
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            lives = lives - 1;
            Destroy(other.gameObject);
            lives_tmp.SetText("Lives: {0}", lives);
        }
    }

    void shootBullet()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && isBulletOnScreen == false)
        {
            if (spriteRenderer.flipX == true)
            {
                var bullet = Instantiate(bulletObject);
                bullet.transform.position = new Vector3(this.GetComponent<BoxCollider2D>().bounds.center.x + this.GetComponent<BoxCollider2D>().bounds.extents.x-1.5f,this.GetComponent<BoxCollider2D>().bounds.center.y,1);
                bullet.GetComponent<BulletScript>().movespeed = -8;
                bullet.GetComponent<BulletScript>().BulletHit += BulletHitEnemy;
                bullet.GetComponent<BulletScript>().EnemyHit += IncreaseScore;
            }
            else
            {
                var bullet = Instantiate(bulletObject);
                bullet.transform.position = new Vector3(this.GetComponent<BoxCollider2D>().bounds.center.x + this.GetComponent<BoxCollider2D>().bounds.extents.x+0.5f,this.GetComponent<BoxCollider2D>().bounds.center.y,1);
                bullet.GetComponent<BulletScript>().movespeed = 8;
                bullet.GetComponent<BulletScript>().BulletHit += BulletHitEnemy;
                bullet.GetComponent<BulletScript>().EnemyHit += IncreaseScore;
            }
            isBulletOnScreen = true;
        }
    }

    void BulletHitEnemy()
    {
        isBulletOnScreen = false;
    }

    void IncreaseScore()
    {
        scores=scores+1;
        scores_tmp.SetText("Score: {0}", scores);
    }
}
