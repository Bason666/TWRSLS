using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
   public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void OpenGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
