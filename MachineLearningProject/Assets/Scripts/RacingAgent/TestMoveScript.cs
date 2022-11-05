using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float inputX;
    private float inputZ;
    private float angle;
    [SerializeField] float rotatationSpeed;
    [SerializeField] private float moveSpeed;    

    //Angle = 30



    private void Awake() {
        rb = GetComponent<Rigidbody>();
        Debug.DrawRay(transform.position, CalcuateVectorRotation(), Color.green, 100f);
        //transform.forward = CalcuateVectorRotation();
    }
    
    
    private void Update() {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        
        angle += inputX * Time.deltaTime * rotatationSpeed;
        transform.localEulerAngles = new Vector3(0, angle, 0);
        
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(90 * inputX, Vector3.up), rotatationSpeed * Time.deltaTime);

        //transform.rotation = Quaternion.AngleAxis(90, Vector3.up); //Always rotates it to y 90 
        //Vector3 newDir = new Vector3(inputX, 0, 0) - transform.forward;
        //transform.forward = Vector3.Lerp(transform.forward, newDir, Time.deltaTime * rotatationSpeed);
    }

    private void FixedUpdate() {
        Vector3 force = Vector3.ClampMagnitude(transform.forward * moveSpeed, 15);
        rb.AddForce(force, ForceMode.Acceleration);
        //rb.velocity = new Vector3(inputX, 0, inputZ) * moveSpeed * Time.deltaTime;
    }
    

    private Vector3 CalcuateVectorRotation(){
        float angle = 30f;
        Vector3 origDir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        Vector3 perpendicularDir = new Vector3(-Mathf.Sin(angle), Mathf.Cos(angle)).normalized;

        Vector3 forward = transform.forward;

        Vector3 result = (forward.x * origDir) + (forward.z * perpendicularDir);
        return (result - transform.position).normalized;
    }
}
