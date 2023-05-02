using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 2f;
    public bool moveUp = true;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (moveUp)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Min(4.3f, startPos.y + Mathf.PingPong(Time.time * speed, distance)), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Mathf.Max(-4.3f, startPos.y - Mathf.PingPong(Time.time * speed, distance)), transform.position.z);
        }
    }
}