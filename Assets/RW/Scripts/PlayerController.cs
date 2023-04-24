using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Vector2 newVelocity = playerRigidbody.velocity;
        newVelocity.x = forwardMovementSpeed;
        playerRigidbody.velocity = newVelocity;

        bool jetpackActive = Input.GetKey("space");
        if (jetpackActive)
        {
            playerRigidbody.AddForce(new Vector2(0, jetpackForce));
        }
    }
}
