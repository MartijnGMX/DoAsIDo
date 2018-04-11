using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRRecorderGlobalController : MonoBehaviour
{
    public VRRecorderController[] controllers;

    public GameObject leftController;
    public GameObject rightController;

    VRTK_ControllerEvents leftCEvents;
    VRTK_ControllerEvents rightCEvents;
    
    public bool inited;

    public FloatValue playBackSpeed;

    // Use this for initialization
    void Start()
    {
        inited = false;
    }

    void Setup()
    {
        leftController = VRTK_DeviceFinder.GetControllerLeftHand();
        rightController = VRTK_DeviceFinder.GetControllerRightHand();
        if (leftController != null && rightController != null)
        {
            leftCEvents = (leftController.GetComponent<VRTK_ControllerEvents>() ? leftController.GetComponent<VRTK_ControllerEvents>() : leftController.GetComponentInParent<VRTK_ControllerEvents>());
            rightCEvents = (rightController.GetComponent<VRTK_ControllerEvents>() ? rightController.GetComponent<VRTK_ControllerEvents>() : rightController.GetComponentInParent<VRTK_ControllerEvents>());
            if (leftCEvents != null && rightCEvents != null)
            {
                rightCEvents.GripClicked += OnRecordPressed;
                rightCEvents.ButtonTwoPressed += OnPlayPressed;
                inited = true;
            }
        }
    }

    private void OnPlayPressed(object sender, ControllerInteractionEventArgs e)
    {
        
        PlayPressed();
    }

    private void OnRecordPressed(object sender, ControllerInteractionEventArgs e)
    {
        RecordPressed();
    }

    void PlayPressed()
    {
        for (int i = 0; i < controllers.Length; i++)
        {
            controllers[i].PlayPressed();
        }
    }

    void RecordPressed()
    {
        for (int i = 0; i < controllers.Length; i++)
        {
            controllers[i].RecordPressed();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (inited)
        {
            
        }
        else
        {
            Setup();
        }
    }
}
