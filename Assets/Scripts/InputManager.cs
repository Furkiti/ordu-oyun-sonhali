using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //public static InputManager Instance;
    public DynamicJoystick joystick;
    public PlayerMovement playerMovement;
    
    private float moveX;
    private float moveZ;
    private Vector3 direction;
    
    [HideInInspector] public bool isPlayerMoving = false;
    
    private void Awake()
    {
        //SingletonPattern();
        
    }
    
    /*#region Singleton

    private void SingletonPattern()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    

    #endregion*/
    
    private void FixedUpdate()
    {
        MovePlayer();
    }

    
    public void MovePlayer()
    {
        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            moveX = joystick.Horizontal;
            moveZ = joystick.Vertical;
            direction = new Vector3(moveX,0,moveZ).normalized;
            
            //PlayerManager.Instance.ChangePlayerAnimState(PlayerManager.PlayerAnimState.Running);
            playerMovement.MovePlayer(direction);
            isPlayerMoving = true;
            
        }
        else
        {
            isPlayerMoving = false;
            //PlayerManager.Instance.ChangePlayerAnimState(PlayerManager.PlayerAnimState.Idle);
        }
    }
    
    
    
    /*public void EnableJoystick()
    {
        //joystick.gameObject.SetActive(true);
    }
    
    public void DisableJoystick()
    {
        //joystick.input = Vector2.zero;
        //joystick.gameObject.SetActive(false);
    }*/
    
}
