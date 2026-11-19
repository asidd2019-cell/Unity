using UnityEngine;

public class EnemyEnergyBallScript : MonoBehaviour
{
    public float movespeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Collider2D bulletCollider = GetComponent<Collider2D>();

        foreach (GameObject enemy in enemies)
        {
            Collider2D enemyCollider = enemy.GetComponent<Collider2D>();

            if (enemyCollider != null && bulletCollider != null)
            {
                Physics2D.IgnoreCollision(bulletCollider, enemyCollider);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        this.transform.Translate(movespeed * Time.deltaTime,0,0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Barrier"))
        {
            Destroy(this.gameObject);
        }
    }
}
