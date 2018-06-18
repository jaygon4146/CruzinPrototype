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

    public float maxWheelAngle = 45f;
    public float maxWheelTorque = 800f;
    public float brakeWheelTorque = 30000f;

    public SimpleWheel FrontLeftWheel;
    public SimpleWheel FrontRightWheel;
    public SimpleWheel BackLeftWheel;
    public SimpleWheel BackRightWheel;

    private List<SimpleWheel> wheelList = new List<SimpleWheel>();

    [SerializeField] private float steerAngle;
    [SerializeField] private float torque;
    [SerializeField] private float handBrake;

    void Awake()
    {
        carInput = GetComponent <InputHandler>();
        wheelList.Add(FrontLeftWheel);
        wheelList.Add(FrontRightWheel);
        wheelList.Add(BackLeftWheel);
        wheelList.Add(BackRightWheel);
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
        } 
    }    

    private void RBForcesFU()
    {

    }


}
