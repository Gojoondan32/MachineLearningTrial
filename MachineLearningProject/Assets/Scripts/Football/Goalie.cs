using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Goalie : Agent
{
    [SerializeField] private Transform ball;

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(ball.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float x = actions.ContinuousActions[0];
        float z = actions.ContinuousActions[1];

        float speed = 6f;
        transform.position += new Vector3(x, 0, z) * speed * Time.deltaTime;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        base.Heuristic(actionsOut);
    }

    private void OnTriggerEnter(Collider other) {
        //This is actually the ball but this just saves having to make another tag
        if(other.gameObject.CompareTag("Goal")){

        }
        else if(other.gameObject.CompareTag("Wall")){
            
        }
    }
}
