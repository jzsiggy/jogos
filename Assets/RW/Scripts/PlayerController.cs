using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 5.0f;
    public int pointsToAdd = 50;

    public Animator ani;
    public AudioClip deathSound;
    public AudioClip coinSound;

    private KeyCode jumpKey;
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        UpdateKeyBindings();
    }

    public void UpdateKeyBindings()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey", "Space"));
        }
        else if (SceneManager.GetActiveScene().name == "Options")
        {
            SceneManager.LoadScene("Options", LoadSceneMode.Single);
            var keyBindingManagerObject = GameObject.Find("KeyBindingManager");
            if (keyBindingManagerObject != null)
            {
                KeyBindingManager keyBindingManager = keyBindingManagerObject.GetComponent<KeyBindingManager>();
                keyBindingManager.UpdateKeyTexts();
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        var keyboard = Keyboard.current;
        bool jetpackActive = Input.GetKey(jumpKey);
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

        bool jetpackActive = Input.GetKey(jumpKey);
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

        if (collision.collider.CompareTag("PowerUp2"))
        {
            AudioManager.Instance.PlayCollectibleSound(coinSound);
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            ScoreManager.score += pointsToAdd;
        }


    }

    public void Die()
    {
        SceneManager.LoadScene("GameOver");
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }
        AudioManager.Instance.PlaySFX(deathSound);
        AudioManager.Instance.PlayDeathMusic();
        
    }
}