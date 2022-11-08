using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Transform obstacleParent;
    private Lane[] lanes;
    private void Awake() {
        int laneSize = 3;
        lanes = transform.GetComponentsInChildren<Lane>();
        for(int i = 0; i < laneSize; i++){
            //lanes[i] = transform.GetComponentsInChildren<Lane>();
        }
    }
    private bool test = false;
    public void ConstructPlatform(){
        DestroyAllObstacles();
        CreateObstacles();
            
    }

    private void DestroyAllObstacles(){
        foreach(Lane lane in lanes)
            lane.DestroyAllObstacles();
    }

    private void CreateObstacles(){
        //Decide which lane to spawn an obstacle
            //*Up to two obstacles should be able to spawn on each row
            //*There should also be a chance that no obstacles spawn
        int totalAmountOfObstacles = lanes[0].GetTotalAmountOfObstacles();
        for(int i = 0; i < totalAmountOfObstacles; i++){
            if(Random.Range(0, 10) < 5) continue; //Don't spawn an obstacle on this row
            int lane = Random.Range(0, 3);
            int amountOfObstacles = Random.Range(1, 3);
            Debug.Log(amountOfObstacles);
            for(int x = 0; x < amountOfObstacles; x++){
                lanes[lane].SpawnObstacle(obstacle, i, Quaternion.identity, obstacleParent);
            }
        }
        

        
    }
}
