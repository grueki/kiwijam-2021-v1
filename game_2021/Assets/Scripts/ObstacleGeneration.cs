using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{   
    public List<GameObject> listOfObstacles = new List<GameObject>();
    public Transform spawnPoint;
    public Transform deletePoint;

    public List<GameObject> activeObstacles = new List<GameObject>();
    private GameObject nextObstacle;

    private float time;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTimer)
        {
            SpawnObstacle();
        }
    }

    //spawn in a random obstacle from the list
    private void SpawnObstacle()
    {
        time = 0;
        spawnTimer = Random.Range(1.0f, 3.0f);
        int index = Random.Range(0, listOfObstacles.Count);
        nextObstacle = listOfObstacles[index];
        GameObject go = Instantiate(nextObstacle, spawnPoint.position, spawnPoint.rotation);
        go.transform.parent = transform;
        activeObstacles.Add(go);
    }

    //delete the obstacle from the back
    public void DeleteObstacle()
    {
        Destroy(activeObstacles[0]);
        activeObstacles.RemoveAt(0);
    }
}