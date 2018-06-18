using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWheel : MonoBehaviour {

    public WheelCollider wCollider;
    public GameObject visualWheel;

    public bool HasAcceleration;
    public bool HasBrakes;
    public bool HasSteering;



    [SerializeField] private Vector3 wheelEuler;
    [SerializeField] private float turn;
    [SerializeField] private float spin;


    void Awake () {
        wCollider = GetComponent<WheelCollider>();
	}
	
	// Update is called once per frame
	void Update () {

        Quaternion q;
        Vector3 p;
        wCollider.GetWorldPose(out p, out q);

        visualWheel.transform.rotation = q;
        
    }
}
