using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolaTarget : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
