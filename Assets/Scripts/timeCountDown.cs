using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCountDown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondLeft = 60;
    public bool takingAway = false;
    gameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
        textDisplay.GetComponent<Text>().text = secondLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondLeft -= 1;
        textDisplay.GetComponent<Text>().text = secondLeft.ToString();

        if (secondLeft == 0)
        {
            if (gm.level == 10)
            {
                gm.menangUI();
            }
            else
            {
                gm.gameOver();
            }
        }
        takingAway = false;
    }
}
