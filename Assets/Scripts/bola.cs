using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    gameManager gm;
    AudioSource iyeeSound;
    AudioSource hoooSound;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
        iyeeSound = GameObject.FindGameObjectWithTag("sound iyee").GetComponent<AudioSource>();
        hoooSound = GameObject.FindGameObjectWithTag("hooo iyee").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "kiper" || collision.tag == "batas bola")
        {
            gm.nyawa -= 1;
            hoooSound.Play();
            Destroy(gameObject);
        }

        if (collision.tag == "goal checker")
        {
            iyeeSound.Play();
            gm.score += 5;

            if (gm.level != 10)
            {
                if (gm.score >= gm.targetScore)
                {
                    if (gm.level == 1 || gm.level == 2 || gm.level == 3)
                    {
                        gm.targetScore += 50;
                    }
                    else if (gm.level == 4 || gm.level == 5 || gm.level == 6)
                    {
                        gm.targetScore += 60;
                    }
                    else if (gm.level == 7 || gm.level == 8)
                    {
                        gm.targetScore += 70;
                    }
                    else if (gm.level == 9)
                    {
                        gm.targetScore += 80;
                    }

                    gm.nextLevel();
                }


                if (gm.level == 10)
                {
                    gm.scoreUI.text = "";
                }

                Destroy(gameObject);
            }

            Destroy(gameObject);
        }

        if (collision.tag == "sasaran")
        {
            iyeeSound.Play();
            gm.score += 10;

            if (gm.level != 10)
            {
                if (gm.score >= gm.targetScore)
                {
                    if (gm.level == 1 || gm.level == 2 || gm.level == 3)
                    {
                        gm.targetScore += 50;
                    }
                    else if (gm.level == 4 || gm.level == 5 || gm.level == 6)
                    {
                        gm.targetScore += 60;
                    }
                    else if (gm.level == 7 || gm.level == 8)
                    {
                        gm.targetScore += 70;
                    }
                    else if (gm.level == 9)
                    {
                        gm.targetScore += 80;
                    }

                    gm.nextLevel();
                }


                if (gm.level == 10)
                {
                    gm.scoreUI.text = "";
                }

                Destroy(gameObject);
            }
        }
    }
}
