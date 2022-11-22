using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GoalPoints _goalPoints;
    [SerializeField] private Goalie _goalie;
    private Rigidbody _rb;
    [SerializeField] private float _force;
    private Vector3 _startPos;
    private Vector3 _ballDirection;
    public Vector3 BallDirection{get{return _ballDirection;}}
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startPos = transform.position;

        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Goal")){
            Debug.Log("Triggering");
            _rb.velocity = Vector3.zero;
            transform.position = _startPos;

            UIManager.Instance.UpdateGoalAndSaves(TypeOfValue.goal);
            _goalie.SetReward(-5f);
            _goalie.EndEpisode();
            
        }
    }

    public void FireTheBall(){
        _ballDirection = CalculatePositionToGoalPoint() - transform.position;
        _rb.AddForce(BallDirection * _force);
    }
    private Vector3 CalculatePositionToGoalPoint(){
        float x = Random.Range(_goalPoints.goalPoints[0].position.x, _goalPoints.goalPoints[1].position.x);
        float y = Random.Range(0f, 1);

        Vector3 goalPoint = new Vector3(x, y, _goalPoints.goalPoints[0].position.z);
        //Debug.Log(goalPoint);
        //return goalPoint - rb.transform.position;
        return goalPoint;
    }
}
