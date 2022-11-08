using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwitcher : MonoBehaviour
{
    [SerializeField] private Vector3[] lanes;
    [SerializeField] private int laneIndex;
    
    private void Awake() {
        laneIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)) laneIndex++;
        else if(Input.GetKeyDown(KeyCode.A)) laneIndex--;
        laneIndex = Mathf.Clamp(laneIndex, 0, 2);

        transform.position = lanes[laneIndex];
    }
}
