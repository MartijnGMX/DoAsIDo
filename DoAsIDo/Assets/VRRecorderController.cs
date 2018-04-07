using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRRecorderController : MonoBehaviour
{
    public AnimationRecorder animRecorder;
    public GameObject recordingVisualizer;
    public GameObject playBackVisualizer;


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
        if (animRecorder.mode == AnimationRecorder.MODE.PLAYING)
        {
            playBackVisualizer.SetActive(false);
            animRecorder.stop = true;
        }
        else
        {
            animRecorder.transformToPlayBack = playBackVisualizer.transform;
            playBackVisualizer.SetActive(true);
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
            animRecorder.transformToRecord = leftController.transform;
            animRecorder.recordingTarget.Clear();

            playBackVisualizer.SetActive(false);

            // could do this always? :
            recordingVisualizer.transform.SetParent(leftController.transform);
            recordingVisualizer.transform.localPosition = Vector3.zero;
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
