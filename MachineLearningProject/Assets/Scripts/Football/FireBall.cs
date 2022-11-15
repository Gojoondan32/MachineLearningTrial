using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WaitTime());
    }
    private IEnumerator WaitTime(){
        yield return new WaitForSeconds(2f);
        ball.FireTheBall();
        StartCoroutine(WaitTime());
    }
    
}
