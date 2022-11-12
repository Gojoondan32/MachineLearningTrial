using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Cat : Agent
{
    //Needs to know the location of the mouse
    [SerializeField] private Transform mouse;
    [SerializeField] private EnvironmentManager environmentManager;

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(Random.Range(-4.4f, 4.4f), 0.3f, Random.Range(-4.4f, 4.4f));
        //transform.localPosition = Vector3.zero;
    }

    
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(mouse.localPosition);
    }
    
    

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        float moveSpeed = 4f;
        transform.localPosition += new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    /*
    private void Update() {
        Collider[] objectsInArea = Physics.OverlapBox(transform.position, new Vector3(0.6f, 0.5f, 0.6f), Quaternion.identity);
        if(objectsInArea.Length > 2){
            //The cat is colliding with something else
        }
    }

    

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(0.6f, 0.5f, 0.6f));
    }
    */ 

    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.CompareTag("Mouse")){
            environmentManager.DistributeRewards(RewardType.catFindMouse);
        }
        else if(other.gameObject.CompareTag("Wall")){
            environmentManager.DistributeRewards(RewardType.catInWall);
        }
        
    }
}
