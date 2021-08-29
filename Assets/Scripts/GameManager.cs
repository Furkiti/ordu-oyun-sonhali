using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winContainer;
    public static GameManager Instance;

    private void Awake()
    {
        SingletonPattern();
    }

    #region Singleton
    
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
        
    
        #endregion
        
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameCompleted()
    {
        winContainer.SetActive(true);
    }
}
