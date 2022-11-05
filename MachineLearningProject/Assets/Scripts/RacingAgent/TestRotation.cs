using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    private Vector3 lookAtPoint;
    [SerializeField] private float rotatationSpeed;
    [SerializeField] private float angle;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, float.MaxValue);
            lookAtPoint = hit.point;
        }
        
        
        float inputX = Input.GetAxisRaw("Horizontal");
        
        angle += inputX * Time.deltaTime * rotatationSpeed;
        transform.localEulerAngles = new Vector3(0, angle, 0);

        //Vector3 dir = (lookAtPoint - transform.position).normalized;
        //transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * rotatationSpeed);
    }
}
