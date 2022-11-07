using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TestMoveScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotatationSpeed;


    [Header("Test")]
    [SerializeField] private Transform obj;

    private void Update() {
        if(Input.GetAxisRaw("Horizontal") != 0){
            Vector3 pointToTurnTo = (transform.forward + transform.right) * Input.GetAxisRaw("Horizontal");
            obj.position = transform.position + pointToTurnTo; //Debugging
            Vector3 newDir = ((pointToTurnTo + transform.position) - transform.position).normalized;
            //Debug.DrawRay(transform.position, newDir, Color.green, 100f);
            transform.forward = Vector3.Lerp(transform.forward, newDir, rotatationSpeed * Time.deltaTime);
        }
        
    }

    private void FixedUpdate() {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
}
