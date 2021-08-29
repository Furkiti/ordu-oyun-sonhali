using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    
    public InputManager inputManager;
    public PlayerStackManager playerStackManager;
    
    public Animator _Animator;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    [HideInInspector] public bool isPlayerBuilding = false;
    
    
    private void Update()
    {
        if (inputManager.isPlayerMoving)
        {
            _Animator.SetBool("Running",true);
        }
        else
        {
            _Animator.SetBool("Running",false);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("ColorChanger"))
        {
            skinnedMeshRenderer.material.color = Color.cyan;
        }

        if (other.tag.Equals("Wood"))
        {
            playerStackManager.StackWood(other);
        }

        if (other.tag.Equals("Field"))
        {
            isPlayerBuilding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Field"))
        {
            isPlayerBuilding = false;
        }
    }
}
