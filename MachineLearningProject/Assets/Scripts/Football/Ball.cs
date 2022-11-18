using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GoalPoints goalPoints;
    [SerializeField] private Goalie goalie;
    private Rigidbody rb;
    [SerializeField] private float force;
    [SerializeField] private float currentTime;
    [SerializeField] private Transform testObj;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;

        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Goal")){
            Debug.Log("Triggering");
            rb.velocity = Vector3.zero;
            transform.position = startPos;

            UIManager.Instance.UpdateGoalAndSaves(TypeOfValue.goal);
            goalie.SetReward(-5f);
            goalie.EndEpisode();
            
        }
    }

    public void FireTheBall(){
        rb.AddForce((CalculatePositionToGoalPoint() - transform.position) * force);
    }
    private Vector3 CalculatePositionToGoalPoint(){
        float x = Random.Range(goalPoints.goalPoints[0].position.x, goalPoints.goalPoints[1].position.x);
        float y = Random.Range(0f, 1);

        Vector3 goalPoint = new Vector3(x, y, goalPoints.goalPoints[0].position.z);
        //Debug.Log(goalPoint);
        //return goalPoint - rb.transform.position;
        return goalPoint;
    }
}
