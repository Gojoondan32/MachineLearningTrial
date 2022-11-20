using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAdministrator : MonoBehaviour
{
    [SerializeField] private Transform[] _boundries;
    [SerializeField] private Transform _foodPrefab;
    [SerializeField] private Lion _animal;
    private void Awake() {
        //Spawn food randomly
        FoodSpawner foodSpawner = new FoodSpawner(_boundries, _foodPrefab);
        CreateFood(foodSpawner);

        //Spawn animal
    }

    private void CreateFood(FoodSpawner foodSpawner){
        for (int i = 0; i < 100; i++)
        {
            foodSpawner.CreateFood();
        }
    }

    private void SpawnAnimal(){

    }
}
