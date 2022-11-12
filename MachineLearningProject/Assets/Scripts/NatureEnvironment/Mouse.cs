using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Mouse : Agent
{
    //Needs to know the location of the cat
    [SerializeField] private Transform cat;
    [SerializeField] private EnvironmentManager environmentManager;

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(Random.Range(-4.4f, 4.4f), 0.15f, Random.Range(-4.4f, 4.4f));
    }

    public override void CollectObservations(VectorSensor sensor){
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(cat.localPosition);
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

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Wall"))
        {
            environmentManager.DistributeRewards(RewardType.mouseInWall);
        }
        

    }
}
