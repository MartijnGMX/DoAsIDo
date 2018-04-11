using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationRecorder : MonoBehaviour
{

    public RecordedSimpleAnimation recordingTarget;

    public Transform transformToRecord;
    public Transform transformToPlayBack;

    public float startTime;
    public float time;
    float prevTime;

    public bool startRecording = false;
    public bool startPlaying = false;
    public bool stop = false;
    

    public bool clear = false;
    public bool cleanup = false;
    [Range(1f, 60f)]
    public float frameRate = 10f;
    [Range(0.001f, 1f)]
    public float epsilon = 0.01f;

    public int numSamples = 0;
    public bool showGizmo = true;

    public delegate void RecorderEvent();
    public RecorderEvent OnStartPlaying;
    public RecorderEvent OnStartRecording;
    public RecorderEvent OnStop;

    public enum MODE
    {
        STOPPED,
        RECORDING,
        PLAYING
    }

    public MODE mode;

    void OnEnable()
    {
        Stop();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        SwitchModes();
        switch (mode)
        {
            case MODE.STOPPED:
                break;
            case MODE.PLAYING:
                time = Time.time - startTime;
                recordingTarget.Play(transformToPlayBack, time);
                prevTime = time;
                if (time > recordingTarget.lengthInSecs)
                {
                    stop = true;
                }
                break;
            case MODE.RECORDING:
                time = Time.time - startTime;
                if (time - prevTime > 1f / frameRate)
                {
                    recordingTarget.Record(transformToRecord, time);
                    prevTime = time;
                }
                break;
            default:
                break;
        }
        numSamples = recordingTarget.timeStamps.Count;
    }

    void Stop()
    {
        time = 0f;
        mode = MODE.STOPPED;
        if (OnStop != null) {
            OnStop.Invoke();
        }
    }

    void StartPlaying()
    {
        startTime = Time.time;
        time = 0f;
        prevTime = -9999f;
        mode = MODE.PLAYING;
        if (OnStartPlaying!=null){
            OnStartPlaying.Invoke();
        }
    }

    void StartRecording()
    {
        startTime = Time.time;
        time = 0f;
        prevTime = -9999f;
        mode = MODE.RECORDING;
        if (OnStartRecording != null) {
            OnStartRecording.Invoke();
        }
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            startPlaying = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            stop = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            startRecording = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            clear = true;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            cleanup = true;
        }
    }

    void SwitchModes()
    {
        if (startPlaying)
        {
            if (mode == MODE.STOPPED)
            {
                StartPlaying();
            }
            startPlaying = false;
        }
        else if (stop)
        {
            if (mode != MODE.STOPPED)
            {
                Stop();
            }
            stop = false;
        }
        else if (startRecording)
        {
            if (mode == MODE.STOPPED)
            {
                StartRecording();
            }
            startRecording = false;
        }
        else if (clear)
        {
            recordingTarget.Clear();
            clear = false;
        }
        else if (cleanup)
        {
            recordingTarget.Cleanup(epsilon);
            cleanup = false;
        }
    }

    void OnDrawGizmos() {
        if (showGizmo && recordingTarget)
        {
            recordingTarget.DrawGizmos();
        }
    }
}
