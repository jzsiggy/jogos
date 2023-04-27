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

    void AddObject()
    {
        int i = Random.Range(0, availableObstacles.Length);
        GameObject obj = (GameObject)Instantiate(availableObstacles[i]);
        float x = transform.position.x + 20f;
        float randomY = Random.Range(obstacleMinY, obstacleMaxY);
        obj.transform.position = new Vector3(x,randomY,0);    
        //obj.transform.localScale = new Vector3(1, 2, 1);
        renderedObstacles.Add(obj);        
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
            // AddObject();
            GenerateObjectsIfRequired();
            yield return new WaitForSeconds(2.25f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
