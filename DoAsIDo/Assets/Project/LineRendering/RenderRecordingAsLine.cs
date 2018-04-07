using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRecordingAsLine : MonoBehaviour {
    public LineRenderer lineRenderer;
    public AnimationRecorder animationRecorder;

	// Use this for initialization
	void OnEnable () {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }

    // Update is called once per frame
    void Update () {
        // todo: optimize
        Vector3[] pos = animationRecorder.recordingTarget.position.ToArray();
        lineRenderer.positionCount = pos.Length;
        lineRenderer.SetPositions(pos);
	}
}
