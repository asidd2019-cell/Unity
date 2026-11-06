using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float movespeed;
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
}
