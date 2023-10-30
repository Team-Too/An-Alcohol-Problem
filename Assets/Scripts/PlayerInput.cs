using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public float Acceleration
    {
        get { return m_Acceleration; }
    }
    public float Steering
    {
        get { return m_Steering; }
    }
    float m_Acceleration;
    float m_Steering;
    bool m_FixedUpdateHappened;
    private bool accelarating = false;
    private bool breaking = false;
    private bool turningLeft = false;
    private bool turningRight = false;
    public float wheelDampening;

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        if(accelarating)
        {
            m_Acceleration = 1f;
            wheelDampening = 500f;
        }
        else if (breaking)
        {
            m_Acceleration = -1f;
            wheelDampening = 10000f;
        }
        else
        {
            m_Acceleration = 0f;
            wheelDampening = 5f;
        }

        if(turningLeft)
            m_Steering = -1f;
        else if(!turningLeft && turningRight)
            m_Steering = 1f;
        else
            m_Steering = 0f;
    }
    private void GetPlayerInput()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            accelarating = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            accelarating = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
        {
            breaking = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
        {
            breaking = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
        {
            turningLeft = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
        {
            turningLeft = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
        {
            turningRight = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
        {
            turningRight = false;
        }
    }
}
