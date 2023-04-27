using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public string playerTag = "Player";

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Insert player death logic here
            collision.gameObject.GetComponent<PlayerController>().Die();

            // Destroy bullet after hitting the player
            Destroy(gameObject);
        }
    }
}
