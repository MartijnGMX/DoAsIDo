using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackPreviewVisualizer : MonoBehaviour {
    public AnimationRecorder recorder;
    public GameObject playbackVisualizerToClone;

    public Transform previewer;

    public float previewInterval = 0.5f; // in seconds
    public int numPreviews=1; // 
    public int index=0;

    public bool active;
    public float myTime;
    public Vector3 myPosition;

    public float lerpVal;

	// Use this for initialization
	void Start () {
        myTime = index * previewInterval;
        GameObject newGO = Instantiate(playbackVisualizerToClone, this.transform);
        newGO.SetActive(true);
        previewer = newGO.transform;

        recorder.OnStartPlaying += OnStartPlay;
        recorder.OnStop += OnStop;

        OnStop();
    }

    void OnStartPlay()
    {
        // start from 0:
        myTime = index * previewInterval;
        myPosition = recorder.recordingTarget.GetInterpolatedPosition(myTime); // TODO: only when needed... i.e. when playback is started
        previewer.gameObject.SetActive(true);
        active = true;
    }

    void OnStop()
    {
        previewer.gameObject.SetActive(false);
        active = false;
    }

    // Update is called once per frame
    void Update () {
        lerpVal = 1f - (myTime - recorder.time) / (previewInterval * numPreviews);
        if (lerpVal >= 1f)
        {
            myTime += (previewInterval * numPreviews);
            myPosition = recorder.recordingTarget.GetInterpolatedPosition(myTime);
            lerpVal = 0f;
        }
        this.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerpVal);
        this.transform.position = myPosition;
	}
}
