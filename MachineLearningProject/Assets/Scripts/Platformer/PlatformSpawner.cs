using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] platforms;
    private int currentIndex; //Will float between 0 and 1
    
    private float currentTime = 4f;

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0f){
            
            currentTime = 4f;
        }
    }
}
