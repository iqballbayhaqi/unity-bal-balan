using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiper : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    gameManager gm;
    [SerializeField] int speed;
    bool levelMoreThanOne = false;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        speed = gm.level * 10;
        if (gm.level == 2 && !levelMoreThanOne)
        {
            levelMoreThanOne = true;
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            if (collision.collider.CompareTag("batasKanan"))
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            if (collision.collider.CompareTag("batasKiri"))
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bola")
        {
            anim.SetTrigger("tengkap");
            Invoke("idleKiper", 1f);
        }
    }

    void idleKiper()
    {
        anim.SetTrigger("idle");
    }
}
