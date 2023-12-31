using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float accel;
    public float deAccel;
    public float velPower;
    Rigidbody2D rb;
    Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float targetSpeed = moveInput.x * moveSpeed;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate;
        if(Mathf.Abs(targetSpeed) > 0.01f) {
            accelRate = accel; //desire to move
        } else {
            accelRate = deAccel; //desire to stop
        }
        //MAKE ACCLERATIONS SPECIFICALLY FOR TURNING THE OTHER DIRECTION(Maybe not needed?)
        float speedChange = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        Debug.Log("Direction: " + moveInput.x);
        Debug.Log("Current Velocity: " + rb.velocity.x);
        Debug.Log(Vector2.right * speedChange);
        rb.AddForce(Vector2.right * speedChange);
    }
    public void Strafe(InputAction.CallbackContext context) {
        
        if(context.performed) {
            moveInput = context.ReadValue<Vector2>();
            
        }
        if(context.canceled) {
            moveInput = context.ReadValue<Vector2>();
        }
    }
    
}
