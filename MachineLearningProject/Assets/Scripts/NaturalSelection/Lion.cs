using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Lion : Agent, IAnimal
{
    private AnimalStats _animalStats;

    //Call when this agent is created 
    public void InheritGenes(AnimalStats animalStats){
        _animalStats = animalStats;
    }
    public override void Initialize()
    {
        //This is called as soon as the agent is created
        base.Initialize();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        base.CollectObservations(sensor);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        base.OnActionReceived(actions);
    }

    
}
