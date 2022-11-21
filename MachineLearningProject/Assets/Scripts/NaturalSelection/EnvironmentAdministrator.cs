using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentAdministrator : MonoBehaviour
{
    public static EnvironmentAdministrator Instance;
    [SerializeField] private Transform[] _boundries;
    [SerializeField] private Transform _foodPrefab;
    [SerializeField] private Lion _animal;
    private void Awake() {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);

        //Spawn food randomly
        FoodSpawner foodSpawner = new FoodSpawner(_boundries, _foodPrefab);
        CreateFood(foodSpawner);

        //Spawn animal
        AnimalStats animalStats = new AnimalStats(0.2f, 1f, 10f);
        BirthAnimal(animalStats, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void CreateFood(FoodSpawner foodSpawner){
        for (int i = 0; i < 100; i++)
        {
            foodSpawner.CreateFood();
        }
    }

    public void BirthAnimal(AnimalStats inheritedStats, Vector3 position, Quaternion rotation){
        Lion animal = Instantiate(_animal, position, rotation);
        animal.InheritGenes(inheritedStats);
    }
}
