using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jetpackForce = 75.0f;
    private Rigidbody2D playerRigidbody;
    public float forwardMovementSpeed = 5.0f;

    public Animator ani;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool jetpackActive = Input.GetKey("space");
        if (jetpackActive)
        {
            ani.SetBool("Grounded", false);
        }
        else
        {
            ani.SetBool("Grounded", true);
        }
    }

    void FixedUpdate() 
    {
        forwardMovementSpeed = forwardMovementSpeed + 0.01f;
        Vector2 newVelocity = playerRigidbody.velocity;
        newVelocity.x = forwardMovementSpeed;
        playerRigidbody.velocity = newVelocity;

        bool jetpackActive = Input.GetKey("space");
        if (jetpackActive)
        {
            playerRigidbody.AddForce(new Vector2(0, jetpackForce));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Die();
        }

        if (collision.collider.CompareTag("PowerUp"))
        {
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            forwardMovementSpeed = forwardMovementSpeed - 2f;
        }
    }

    void Die()
    {
        // Your player death logic, like playing a death animation or sound effect
        // Example: Restart the current scene
        SceneManager.LoadScene("MainMenu");
    }
}
