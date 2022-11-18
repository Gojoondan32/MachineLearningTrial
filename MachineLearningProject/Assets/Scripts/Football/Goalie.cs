using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Goalie : Agent
{
    [SerializeField] private Transform ball;
    [SerializeField] private Transform goal; 
    [SerializeField] private GoalPoints goalPoints;
    [SerializeField] private Transform[] walls;

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(0, 0.45f, 1.25f);
        ball.localPosition = new Vector3(0, 0.1f, -1.7f);

        ball.GetComponent<Ball>().FireTheBall();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(ball.transform.localPosition);
        foreach(Transform points in goalPoints.goalPoints){
            sensor.AddObservation(points.localPosition.x);
            sensor.AddObservation(points.localPosition.y);
            sensor.AddObservation(points.localPosition.z);
        }

        foreach(Transform wallPoints in walls){
            sensor.AddObservation(wallPoints.localPosition.x);
            sensor.AddObservation(wallPoints.localPosition.y);
            sensor.AddObservation(wallPoints.localPosition.z);
        }

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float x = actions.ContinuousActions[0];
        float z = actions.ContinuousActions[1];

        float speed = 6f;
        transform.localPosition += new Vector3(x, 0, z) * speed * Time.deltaTime;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        base.Heuristic(actionsOut);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ball")){
            UIManager.Instance.UpdateGoalAndSaves(TypeOfValue.save);
            SetReward(1f);
            EndEpisode();
        }
        else if(other.gameObject.CompareTag("Wall")){
            SetReward(-1f);
            EndEpisode();
        }
    }
}
