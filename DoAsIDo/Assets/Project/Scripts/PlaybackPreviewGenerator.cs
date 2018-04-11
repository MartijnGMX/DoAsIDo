using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackPreviewGenerator : MonoBehaviour {
    public PlaybackPreviewVisualizer[] previews;

    public AnimationRecorder recorder;
    public GameObject playbackVisualizerToClone;
    
    public float previewInterval = 0.5f; // in seconds
    public int numPreviews=1; // 
    public int index=0;

	// Use this for initialization
	void Awake () {
        previews = new PlaybackPreviewVisualizer[numPreviews];
        for (int i=0; i< numPreviews; i++)
        {
            GameObject go = new GameObject();
            go.transform.SetParent(this.transform);
            previews[i] = go.AddComponent<PlaybackPreviewVisualizer>();
            previews[i].index = i;
            previews[i].name = "Preview "+i;
            previews[i].previewInterval = previewInterval;
            previews[i].numPreviews = numPreviews;
            previews[i].playbackVisualizerToClone = playbackVisualizerToClone;
            previews[i].recorder = recorder;
        }

    }
}
