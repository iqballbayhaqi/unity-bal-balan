using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public GameObject tutor;

    public void openTutor()
    {
        tutor.SetActive(true);
    }
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
}
