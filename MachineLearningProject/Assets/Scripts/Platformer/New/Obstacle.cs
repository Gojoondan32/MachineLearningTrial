using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType{
    passable,
    wall
}

public class Obstacle : MonoBehaviour{
    [SerializeField] private ObstacleType obstacleType;
    public ObstacleType GetObstacleType{get;}

    [SerializeField] private float speed;

    private void Update() {
        transform.position += -Vector3.forward * speed * Time.deltaTime;

    }
}

