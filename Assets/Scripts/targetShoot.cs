using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetShoot : MonoBehaviour
{
    [SerializeField] int speed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
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
}
