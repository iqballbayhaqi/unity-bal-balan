using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sasaran : MonoBehaviour
{
    gameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bola")
        {
                if (transform.position.x == 1.239f)
                {
                    transform.position = new Vector2(-1.162f, transform.position.y);
                } else
                {
                    transform.position = new Vector2(1.239f, transform.position.y);
                }
        }
    }
}
