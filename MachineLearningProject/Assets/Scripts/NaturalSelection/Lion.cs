using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Lion : Agent, IAnimal
{
    private AnimalStats _animalStats;
    private float statValue;

    //Call when this agent is created 
    public void InheritGenes(AnimalStats animalStats){
        _animalStats = animalStats;
        
        transform.localScale = _animalStats.GetCurrentSize();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        base.CollectObservations(sensor);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float x = actions.ContinuousActions[0];
        float z = actions.ContinuousActions[1];
        statValue = actions.ContinuousActions[2];

        transform.position += new Vector3(x, 0, z) * _animalStats.GetSpeed() * Time.deltaTime;
    }

    private void IncreaseStat(){
        
    }
    
    public void BirthOffspring(){
        //The animal stats will need some changing to them
        EnvironmentAdministrator.Instance.BirthAnimal(_animalStats, transform.position, Quaternion.identity);
    }
    
}
