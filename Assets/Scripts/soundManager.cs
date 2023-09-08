using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioSource audio;
    public GameObject pauseButton;
    public GameObject playButton;

    public void playMusic()
    {
        audio.Play();
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void pauseMusic()
    {
        audio.Pause();
        pauseButton.SetActive(false);
        playButton.SetActive(true);
    }
}
