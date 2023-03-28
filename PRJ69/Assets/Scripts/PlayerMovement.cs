using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D playerRb;
    Vector2 movement;

    public Joystick joystick;
    void Update()
    {
        //PC CONTROLS
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        //MOBILE CONTROLS
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        //ROTATE PLAYER WITH JOYSTICK
        Vector3 moveVector = (Vector3.up * joystick.Horizontal + Vector3.left * joystick.Vertical);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
          transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }
    }

     void FixedUpdate()
    {
        playerRb.position = (playerRb.position + movement * moveSpeed * Time.deltaTime);
        
    }
}
