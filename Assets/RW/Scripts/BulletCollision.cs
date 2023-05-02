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
            collision.gameObject.GetComponent<PlayerController>().Die();

            Destroy(gameObject);
        }
    }
}
