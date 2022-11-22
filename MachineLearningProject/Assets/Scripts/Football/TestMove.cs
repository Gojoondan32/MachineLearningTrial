using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    private Rigidbody rb;
    private float x;
    private float z;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        //x = Input.GetAxisRaw("Horizontal");
        //z = Input.GetAxisRaw("Vertical");
        
        //transform.position += new Vector3(x, 0, z) * speed * Time.deltaTime;
        
    }

    private void FixedUpdate() {
        //rb.velocity = new Vector3(x, 0, z) * speed * Time.deltaTime;
    }
    
}
