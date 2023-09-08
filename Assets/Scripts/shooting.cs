using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public bool Player = true;
    gameManager gm;
    AudioSource dungSound;

    public float fireRate = 1F;
    private float nextFire = 0.0F;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
        dungSound = GameObject.FindGameObjectWithTag("dung sound").GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
          nextFire = Time.time + fireRate;
          dungSound.Play();
          GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
          Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
          rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        }

    }
}
