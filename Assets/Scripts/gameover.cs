using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public void replayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }  

    public void exit()
    {
        SceneManager.LoadScene(0);
    }
}
