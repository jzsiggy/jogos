using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRender : MonoBehaviour
{
    public GameObject[] availableObstacles;
    public List<GameObject> renderedObstacles;

    public float obstacleMinY = -5f;
    public float obstacleMaxY = 5f;

    private float screenWidthInPoints;

    // Start is called before the first frame update
    void Start()
    {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;
        StartCoroutine(GeneratorCheck());
    }

    bool PositionIsValid(Vector3 position, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(position, radius);
        return hitColliders.Length == 0;
    }


    void AddObject()
    {
        int i = Random.Range(0, availableObstacles.Length);
        float x = transform.position.x + 20f;
        float randomY = Random.Range(obstacleMinY, obstacleMaxY);
        Vector3 position = new Vector3(x, randomY, 0);

        if (PositionIsValid(position, 1.0f))
        {
            GameObject obj = (GameObject)Instantiate(availableObstacles[i]);
            obj.transform.position = position;
            renderedObstacles.Add(obj);
        }
    }

    void RemoveOffscreenObjects()
    {
        float playerX = transform.position.x;
        float removeObjectsX = playerX - screenWidthInPoints;

        List<GameObject> objectsToRemove = new List<GameObject>();

        foreach (var obj in renderedObstacles)
        {
            float objX = obj.transform.position.x;
            if (objX < removeObjectsX)
            {
                objectsToRemove.Add(obj);
            }
        }

        foreach (var obj in objectsToRemove)
        {
            renderedObstacles.Remove(obj);
            Destroy(obj);
        }
    }




    void GenerateObjectsIfRequired()
    {
        float playerX = transform.position.x;
        float removeObjectsX = playerX - screenWidthInPoints;
        float addObjectX = playerX + screenWidthInPoints;

        AddObject();
        
        List<GameObject> objectsToRemove = new List<GameObject>();
        foreach (var obj in renderedObstacles)
        {
            float objX = obj.transform.position.x;
            if (objX < removeObjectsX) 
            {           
                objectsToRemove.Add(obj);
            }
        }
        foreach (var obj in objectsToRemove)
        {
            renderedObstacles.Remove(obj);
            Destroy(obj);
        }
    }

    private IEnumerator GeneratorCheck()
    {
        while (true)
        {
            GenerateObjectsIfRequired();
            RemoveOffscreenObjects(); // Add this line
            yield return new WaitForSeconds(2.25f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
