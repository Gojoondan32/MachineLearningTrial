using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private Vector3[] laneSpawnpoints;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject passablePrefab;

    private void CreateNewObjects(){
        for(int i = 0; i < laneSpawnpoints.Length; i++){
            
        }
    }
}
