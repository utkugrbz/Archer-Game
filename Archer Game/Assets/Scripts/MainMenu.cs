using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
    

}
