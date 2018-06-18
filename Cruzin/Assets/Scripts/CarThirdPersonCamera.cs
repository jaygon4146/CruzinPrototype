using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarThirdPersonCamera : MonoBehaviour {

    public Transform lookAt;
    public Transform targetFrom;

    public float lookAbove = 2f;
    public float maximumCameraOffset = 4;
    public float maximumAngleOffset = 22.5f;

    [SerializeField] private float goalYRotation;

    private void FixedUpdate()
    {
        Vector3 positionOffset = targetFrom.position - transform.position;
        float offsetMagnitude = positionOffset.magnitude;
        float lerp = offsetMagnitude / maximumCameraOffset;

        Vector3 moveToPosition = Vector3.Lerp(transform.position, targetFrom.position, lerp);
        transform.position = moveToPosition;



        transform.LookAt(lookAt);




    }


}
