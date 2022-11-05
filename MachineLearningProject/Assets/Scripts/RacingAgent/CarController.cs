using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float inputX;
    private float inputZ;
    private float currentSteeringAngle;
    private float currentBreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce; 
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider backLeftCollider;
    [SerializeField] private WheelCollider backRightCollider;


    [SerializeField] private Transform frontLeftTransfrom;
    [SerializeField] private Transform frontRightTransfrom;
    [SerializeField] private Transform backLeftTransfrom;
    [SerializeField] private Transform backRightTransfrom;


    private void FixedUpdate() {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    
    private void GetInput(){
        inputX = Input.GetAxis(HORIZONTAL);
        inputZ = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor(){
        frontLeftCollider.motorTorque = inputZ * motorForce;
        frontRightCollider.motorTorque = inputZ * motorForce;

        currentBreakForce = isBreaking ? breakForce : 0f;
        if(isBreaking) ApplyBreaking();
    }
    private void ApplyBreaking(){
        frontRightCollider.brakeTorque = currentBreakForce;
        frontLeftCollider.brakeTorque = currentBreakForce;
        backRightCollider.brakeTorque = currentBreakForce;
        backLeftCollider.brakeTorque = currentBreakForce;
    }
    private void HandleSteering(){
        currentSteeringAngle = maxSteeringAngle * inputX;
        frontLeftCollider.steerAngle = currentSteeringAngle;
        frontRightCollider.steerAngle = currentSteeringAngle;
    }
    private void UpdateWheels(){
        UpdateSingleWheel(frontLeftCollider, frontLeftTransfrom);
        UpdateSingleWheel(frontRightCollider, frontRightTransfrom);
        UpdateSingleWheel(backLeftCollider, backLeftTransfrom);
        UpdateSingleWheel(backRightCollider, backRightTransfrom);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransfrom){
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);

        wheelTransfrom.position = pos;
        wheelTransfrom.rotation = rot;
    }
}
