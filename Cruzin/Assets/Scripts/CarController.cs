using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public enum ControlType
    {
        WheelTorque,
        RBForces,
    }

    public ControlType controlType = ControlType.WheelTorque;
    private InputHandler carInput;
    private Rigidbody carRB;

    public Transform carCenterOfMass;
    public List<SimpleWheel> wheelList = new List<SimpleWheel>();

    public float enginePower = 400f;
    public float turnPower = 10f;

    [SerializeField] private float currentSpeed;
    public float maxSpeed = 150f;
    public float acceleration = 5f;
    public float decceleration = 10f;
    public float reverseMaxSpeed = 20f;
    public float reverseAcceleration = 2.5f;
    public float reverseDecceleration = 10f;


    void Awake()
    {
        carInput = GetComponent <InputHandler>();
        carRB = GetComponent<Rigidbody>();

        carRB.centerOfMass = carCenterOfMass.localPosition;

    }
    
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (controlType == ControlType.WheelTorque)
        {
            WheelTorqueFU();
        }
        if (controlType == ControlType.RBForces)
        {
            RBForcesFU();
        }
    }

    private void WheelTorqueFU()
    {
        #region testing
        /*
        steerAngle = maxWheelAngle * carInput.SteerAction.axisFloat;
        torque = maxWheelTorque * carInput.AccelerateAction.axisFloat;

        handBrake = carInput.BrakeAction.buttonHeld ? brakeWheelTorque : 0;

        foreach (SimpleWheel wheel in wheelList)
        {
            if (wheel.HasSteering)
            {
                wheel.wCollider.steerAngle = steerAngle;
            }
            if (wheel.HasBrakes)
            {
                wheel.wCollider.brakeTorque = handBrake;
            }
            if (wheel.HasAcceleration)
            {
                wheel.wCollider.motorTorque = torque;
            }
        }*/
        #endregion

        float torque = carInput.AccelerateAction.axisFloat * enginePower;
        float turnSpeed = carInput.SteerAction.axisFloat * turnPower;
        float brakeTorque = carInput.BrakeAction.buttonHeld ? enginePower : 0;


        foreach (SimpleWheel wheel in wheelList)
        {
            if (wheel.HasSteering)
            {
                wheel.wCollider.steerAngle = turnSpeed;
            }
            if (wheel.HasBrakes)
            {
                wheel.wCollider.brakeTorque = brakeTorque;
            }
            if (wheel.HasAcceleration)
            {
                wheel.wCollider.motorTorque = torque;
            }
        }

        currentSpeed = carRB.velocity.magnitude;
        

    }    

    private void RBForcesFU()
    {

    }


}
