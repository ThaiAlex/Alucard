using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame() //Start button starts ganme
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //When press start button next scene starts (i have not added the next scene)
        SoundManager.Instance.PlaySound3D("Click", transform.position);
    }

}
//Saga