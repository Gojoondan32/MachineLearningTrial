using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField] private LaneManager laneManager;
    [SerializeField] private Transform startPoint;
    [SerializeField] private float speed;
    private void Update() {
        transform.position += -Vector3.forward * speed * Time.deltaTime;
        if(transform.position.z < -15){
            //Spawn the obstacles here
            laneManager.ConstructPlatform();
            transform.position = startPoint.position;
        }
    }

}
