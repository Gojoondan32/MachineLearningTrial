using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    //!Old Stuff
    //[SerializeField] private Transform[] obstacleSpawnpoints;
    //[SerializeField] private GameObject obstaclePrefab;

    
    [SerializeField] private Vector3[] obstacleSpawnpoints;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject passablePrefab;

    private float tempTime; 

    private void Update(){
        tempTime += Time.deltaTime;
        if(tempTime >= 5){
            tempTime = 0f;
            CreateNewObjects();
        }
    }

    private void CreateNewObjects(){
        int randomValue = Random.Range(0, 2);
        //bool reverseDefaultRotation = Random.Range(0, 2) == 1 ? true : false;
        //Instantiate(obstaclePrefab, new Vector3(0, 1, 20), Quaternion.AngleAxis(reverseDefaultRotation ? 180 : 0, Vector3.up));
        int size = 3;
        int wallUsed = 1;
        int passableUsed = 1;
        //GameObject[] objectsToSpawn = new GameObject[size];
        for(int i = 0; i < size; i++){
            GameObject typeOfWall = Random.Range(0, 2) == 1 ? passablePrefab : wallPrefab;
            
           Instantiate(typeOfWall, obstacleSpawnpoints[i], Quaternion.identity);
        }


    }
}
