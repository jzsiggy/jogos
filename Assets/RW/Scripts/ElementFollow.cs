using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementFollow : MonoBehaviour
{
    public GameObject targetObject;
    private float distanceToTarget;

    // Start is called before the first frame update
    void Start()
    {
        distanceToTarget = transform.position.x - targetObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float targetObjectX = targetObject.transform.position.x;
        Vector3 newElementPosition = transform.position;
        newElementPosition.x = targetObjectX + distanceToTarget;
        transform.position = newElementPosition;
    }
}
