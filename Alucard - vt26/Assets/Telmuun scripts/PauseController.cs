using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public static bool IsGamePaused { get; private set; } = false;




    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void SetPause(bool pause)
    {
        IsGamePaused = pause;
    }

    
}
