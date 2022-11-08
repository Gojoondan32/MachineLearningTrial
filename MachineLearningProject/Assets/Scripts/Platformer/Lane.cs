using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    private GameObject[] obstacles;
    private List<GameObject> currentObstacles;

    private void Awake()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Wall");
        currentObstacles = new List<GameObject>();
    }

    public void SpawnObstacle(GameObject obstacle, int row, Quaternion rotation, Transform parent){
        GameObject tempObstacle = Instantiate(obstacle, obstacles[row].transform.position, rotation, parent);
        tempObstacle.transform.localScale = new Vector3(0.1f, 1, 0.025f);
        currentObstacles.Add(tempObstacle);
    }
    public void DestroyAllObstacles(){
        foreach(GameObject obstacle in currentObstacles){
            Destroy(obstacle);
        }
    }

    public int GetTotalAmountOfObstacles() => obstacles.Length;
}
