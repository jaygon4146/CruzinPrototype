using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWheelAxle : MonoBehaviour {

    public WheelCollider leftWheel;
    public WheelCollider rightWheel;

    public float antiRoll = 5000f;

    public Rigidbody carRB;

    private void FixedUpdate()
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = leftWheel.GetGroundHit(out hit);
        if (groundedL)
            travelL = (-leftWheel.transform.InverseTransformPoint(hit.point).y - leftWheel.radius) / leftWheel.suspensionDistance;

        bool groundedR = rightWheel.GetGroundHit(out hit);
        if (groundedR)
            travelR = (-rightWheel.transform.InverseTransformPoint(hit.point).y - rightWheel.radius) / rightWheel.suspensionDistance;


        float antiRollForce = (travelL - travelR) * antiRoll;

        if (groundedL)
            carRB.AddForceAtPosition(leftWheel.transform.up * -antiRollForce, leftWheel.transform.position);

        if (groundedR)
            carRB.AddForceAtPosition(rightWheel.transform.up * -antiRollForce, rightWheel.transform.position);

    }

}
