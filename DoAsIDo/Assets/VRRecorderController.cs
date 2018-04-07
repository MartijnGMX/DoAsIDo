using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRRecorderController : MonoBehaviour
{
    public AnimationRecorder animRecorder;

    public GameObject leftController;
    public GameObject rightController;

    VRTK_ControllerEvents leftCEvents;
    VRTK_ControllerEvents rightCEvents;
    
    public bool inited;

    public bool leftTrigger;
    public bool rightTrigger;

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
                rightCEvents.GripClicked += RightCEvents_GripClicked;
                rightCEvents.StartMenuPressed += RightCEvents_StartMenuPressed;
                inited = true;
            }
        }
    }

    private void RightCEvents_StartMenuPressed(object sender, ControllerInteractionEventArgs e)
    {
        PlayPressed();
    }

    private void RightCEvents_GripClicked(object sender, ControllerInteractionEventArgs e)
    {
        RecordPressed();
    }

    void PlayPressed()
    {
        if (animRecorder.mode == AnimationRecorder.MODE.PLAYING)
        {
            animRecorder.stop = true;
        }
        else
        {
            animRecorder.startPlaying = true;
        }
    }

    void RecordPressed()
    {
        if (animRecorder.mode == AnimationRecorder.MODE.RECORDING)
        {
            animRecorder.stop = true;
        }
        else
        {
            animRecorder.startRecording = true;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (inited)
        {
            leftTrigger = leftCEvents.triggerClicked;
            rightTrigger = rightCEvents.triggerClicked;
        }
        else
        {
            Setup();
        }
    }
}
