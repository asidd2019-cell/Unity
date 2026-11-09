using UnityEngine;
using System;

public class BulletScript : MonoBehaviour
{

    public float movespeed;
    public event Action BulletHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            BulletHit?.Invoke();
        }
    }
}
