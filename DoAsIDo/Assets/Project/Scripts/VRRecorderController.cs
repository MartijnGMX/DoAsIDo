using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRRecorderController : MonoBehaviour
{
    public AnimationRecorder animRecorder;
    public GameObject recordingVisualizer;
    public GameObject playBackVisualizer;
    public GameObject followingObject; // during playback, the object that the player controls, which he tries to match up to playBackVisualizer.
                                        // May be the same as recordingVisualizer

    public void PlayPressed()
    {
        if (animRecorder.mode == AnimationRecorder.MODE.PLAYING)
        {
            playBackVisualizer.SetActive(false);
            recordingVisualizer.SetActive(false);
            followingObject.SetActive(false);
            animRecorder.stop = true;
        }
        else
        {
            animRecorder.transformToPlayBack = playBackVisualizer.transform;
            playBackVisualizer.SetActive(true);
            recordingVisualizer.SetActive(false);
            followingObject.SetActive(true);
            animRecorder.startPlaying = true;
        }
    }

    public void RecordPressed()
    {
        if (animRecorder.mode == AnimationRecorder.MODE.RECORDING)
        {
            playBackVisualizer.SetActive(false);
            recordingVisualizer.SetActive(false);
            followingObject.SetActive(false);
            animRecorder.stop = true;
        }
        else
        {
            animRecorder.transformToRecord = recordingVisualizer.transform;
            animRecorder.recordingTarget.Clear();

            playBackVisualizer.SetActive(false);
            followingObject.SetActive(false);
            recordingVisualizer.SetActive(true);
            animRecorder.startRecording = true;
        }
    }
}
