using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float bulletSpeed = 5f;
    public float bulletLifetime = 5f;

    private Transform player;
    private float timeSinceLastShot;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= 1f / fireRate)
        {
            ShootAtPlayer();
            timeSinceLastShot = 0f;
        }
    }

    void ShootAtPlayer()
    {
        if (player != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Vector2 direction = (player.position - transform.position).normalized;

            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }
}