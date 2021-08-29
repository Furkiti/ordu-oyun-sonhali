using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private float playerSpeed;
    private float rotationSpeed;
    
    private CharacterController _characterController;

    //Gravity
    public Transform groundCheck;
    private float groundDistance = 0.4f;
    private LayerMask groundMask;

    private bool isGrounded;

    private Vector3 velocity;
    private float gravity = -4f;
    

    void Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        playerSpeed = .2f;
        rotationSpeed = 20;
    }
    
    private void Update()
    {
        //Apply Gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        velocity.y += gravity * Time.fixedDeltaTime;
        _characterController.Move(velocity);
    }

    public void MovePlayer(Vector3 direction)
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation,Quaternion.LookRotation(direction),rotationSpeed*Time.fixedDeltaTime);
        direction *= playerSpeed;
        
        _characterController.Move(direction);
        
        
        
        /*_rigidbody.MovePosition(new Vector3(
                                transform.position.x + (horizontal * speed * Time.fixedDeltaTime),
                                transform.position.y,
                                transform.position.z + (vertical * speed * Time.fixedDeltaTime)
                            ));*/
        
        
        //transform.position += ;
        
        
    }
    
    
}