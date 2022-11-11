using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class Mouse : Agent
{
    //Needs to know the location of the cheese
    //Needs to know the location of the cat

    public override void CollectObservations(VectorSensor sensor){
        sensor.AddObservation(transform.position);
        sensor.AddObservation(PositionInformation.Instance.GetObjectPosition(ObjectType.cheese));
        sensor.AddObservation(PositionInformation.Instance.GetObjectPosition(ObjectType.mouse));
    }

    
}
