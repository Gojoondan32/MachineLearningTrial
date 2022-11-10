using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType {passable, wall}

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ObstacleType obstacleType;
    public ObstacleType GetObstacleType{get; private set;}
}
