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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeObstacles.Count == 0)
        {
            SpawnObstacle();
        }
        else if (activeObstacles[0].transform.position.x <= deletePoint.position.x)
        {
            DeleteObstacle();
        }
    }

    //spawn in a random obstacle from the list
    private void SpawnObstacle()
    {
        int index = Random.Range(0, listOfObstacles.Count);
        nextObstacle = listOfObstacles[index];
        GameObject go = Instantiate(nextObstacle, spawnPoint.position, spawnPoint.rotation);
        activeObstacles.Add(go);
    }

    //delete the obstacle from the back
    public void DeleteObstacle()
    {
        Destroy(activeObstacles[0]);
        activeObstacles.RemoveAt(0);
    }
}