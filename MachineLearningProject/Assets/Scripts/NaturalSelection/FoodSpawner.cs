using UnityEngine;

public class FoodSpawner
{
    private Transform[] _spawnBoundries;    
    private Transform _foodPrefab;
    public FoodSpawner(Transform[] spawnBoundries, Transform foodPrefab){
        if(spawnBoundries.Length > 2){
            Debug.LogError("Length of array is too long");
            return;
        }
        this._spawnBoundries = spawnBoundries;
        this._foodPrefab = foodPrefab;
    }

    public void CreateFood(){
        float x = Random.Range(_spawnBoundries[0].position.x, _spawnBoundries[1].position.x);
        float y = 0.1f;
        float z = Random.Range(_spawnBoundries[0].position.z, _spawnBoundries[1].position.z);

        Vector3 posToSpawn = new Vector3(x, y, z);
        GameObject.Instantiate(_foodPrefab, posToSpawn, Quaternion.identity);
    }
}
