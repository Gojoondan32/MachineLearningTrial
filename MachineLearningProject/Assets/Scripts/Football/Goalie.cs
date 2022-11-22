using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Goalie : Agent
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _goal; 
    [SerializeField] private GoalPoints _goalPoints;
    [SerializeField] private Transform[] _walls;

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(0, 0.45f, 1.25f);
        _ball.transform.localPosition = new Vector3(0, 0.1f, -1.7f);
        _ball.FireTheBall();
        //ball.GetComponent<Ball>().FireTheBall();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(_ball.transform.localPosition);
        sensor.AddObservation(_ball.BallDirection);
        sensor.AddObservation(_goal.localPosition);
        foreach(Transform points in _goalPoints.goalPoints){
            sensor.AddObservation(points.localPosition.x);
            sensor.AddObservation(points.localPosition.y);
            sensor.AddObservation(points.localPosition.z);
        }

        foreach(Transform wallPoints in _walls){
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
            SetReward(5f);
            EndEpisode();
        }
        else if(other.gameObject.CompareTag("Wall")){
            SetReward(-1f);
            EndEpisode();
        }
    }
}
