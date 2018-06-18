using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : InputUtilities {
    
    public InputAction SteerAction = new InputAction("Steer");
    public InputAction AccelerateAction = new InputAction("Accelerate");
    public InputAction BrakeAction = new InputAction("Brake");

    private void Awake()
    {
        SetUpInputs();

    }
    private void SetUpInputs()
    {
        SteerAction.AddAxis("Horizontal");
        AccelerateAction.AddAxis("Accelerate");
        BrakeAction.AddButton("Brake");
    }  

    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        SteerAction.GetInput();
        BrakeAction.GetInput();
        AccelerateAction.GetInput();        
    }

    private void FixedUpdate()
    {
    }


}
