using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform[] goalMarkers;
    private Rigidbody rb;
    [SerializeField] private float force;
    [SerializeField] private Transform testObj;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            //Fire ball
            Debug.Log("Firing");
            //testObj.position = CalculatePositionToGoalPoint();
            rb.AddForce((CalculatePositionToGoalPoint() - transform.position) * force);
        }
        else if(Input.GetMouseButtonDown(1)){
            rb.velocity = Vector3.zero;
            transform.position = startPos;
        }
            
    }



    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Goal")){
            rb.velocity = Vector3.zero;
            transform.position = startPos;
        }
    }

    private Vector3 CalculatePositionToGoalPoint(){
        float x = Random.Range(goalMarkers[0].position.x, goalMarkers[1].position.x);
        float y = Random.Range(0f, 1);

        Vector3 goalPoint = new Vector3(x, y, goalMarkers[0].position.z);
        Debug.Log(goalPoint);
        //return goalPoint - rb.transform.position;
        return goalPoint;
    }
}
