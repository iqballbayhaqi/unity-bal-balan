using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public int score = 0;
    public int level = 1;
    public int nyawa = 3;
    public int targetScore = 70;
    public bool isCanShoot = true;

    public Text scoreUI;
    [SerializeField] Text targetScoreUI;
    [SerializeField] Text levelUI;
    [SerializeField] GameObject[] nyawaUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] Text finalScoreUI;
    [SerializeField] Sprite kalahImage;
    [SerializeField] Image ImageGameOver;
    [SerializeField] timeCountDown time;

    float scoreSebelumnya = 0;
    private void Update()
    {
        scoreUI.text = score.ToString();
        targetScoreUI.text = "Target Score : " + targetScore.ToString();
        levelUI.text = "Level " + level;

        if (score != scoreSebelumnya)
        {
            postData network = GetComponent<postData>();
            scoreSebelumnya = score;
            network.postDataScore(score);
        }

        // if (nyawa == 2)
        // {
        //     nyawaUI[0].SetActive(false);
        // } else if (nyawa == 1)
        // {
        //     nyawaUI[1].SetActive(false);
        // }else if (nyawa == 0)
        // {
        //     nyawaUI[2].SetActive(false);
        // kalah
        //     gameOver();
        // }
    }

    public void nextLevel()
    {
        level += 1;
        time.secondLeft = 60;

        if (level == 11)
        {
            // menang
            GameOverUI.SetActive(true);
            finalScoreUI.text = score.ToString();
        }
    }

    public void gameOver()
    {
        GameOverUI.SetActive(true);
        ImageGameOver.sprite = kalahImage;
        finalScoreUI.text = score.ToString();
    }

    public void menangUI()
    {
        // menang
        GameOverUI.SetActive(true);
        finalScoreUI.text = score.ToString();
    }
}
