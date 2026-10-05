using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour

{
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 6;
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
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            this.transform.Translate(moveSpeed * Time.deltaTime,0,0);
        }
    }
}
