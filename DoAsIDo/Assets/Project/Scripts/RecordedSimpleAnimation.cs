using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="RecordedSimpleAnimation", menuName= "RecordedSimpleAnimation")]   
public class RecordedSimpleAnimation : ScriptableObject {
    public List<Vector3> position;
    [SerializeField]
    public List<float> timeStamps;

    public float lengthInSecs
    {
        get { return timeStamps.Count > 0 ?
                timeStamps[timeStamps.Count - 1]
                : 0 ;
        }
    }

    // helper
    // int lastIndex;

    public void Clear()
    {
        position.Clear();
        timeStamps.Clear();
    }

    public void Record(Transform trans, float time)
    {
        position.Add(trans.position);
        timeStamps.Add(time);
    }

    // reset the playhead
    public void Stop()
    {
    }

    // find the indices in the arrays that surround a given timeStamp
    // alpha is the interpolation value between 'before' and 'after' (in [0..1])
    public void GetIndices(float time, out int before, out int after, out float alpha)
    {
        int i = 0;
        int N = timeStamps.Count;
        while (i < N && timeStamps[i] <= time)
        {
            i++;
        }
        if (i < N)
        {
            before = i - 1;
            after = i;
            alpha = (time - timeStamps[before]) / (timeStamps[after] - timeStamps[before]);
        } else {
            // i==N
            // time lies beyond any timeStamp in the list. Just return the last item:
            before = N - 1;
            after = N - 1;
            alpha = 0f;
        }
    }

    public void Play(Transform trans, float time)
    {
        int a;
        int b;
        float t;
        if (position.Count > 0)
        {
            GetIndices(time, out a, out b, out t);
            trans.position = Vector3.Lerp(position[a], position[b], t); // linearly interpolate
        }
    }

    public void Cleanup(float epsilon)
    {
        float e2 = epsilon * epsilon;
        for (int i = position.Count - 2; i > 1; i--)
        { // leave the last sample intact
            Vector3 posA = position[i - 1];
            Vector3 posB = position[i];
            if (Vector3.SqrMagnitude(posA - posB) < e2)
            {
                position.RemoveAt(i);
                timeStamps.RemoveAt(i);
            }
        }
    }

    public void DrawGizmos()
    {
        for (int i = 0; i < position.Count - 1; i++) {
            float time = timeStamps[i];
            Gizmos.color = Color.Lerp(Color.black, Color.white, i % 2); // time - Mathf.Floor(time));
            Gizmos.DrawLine(position[i], position[i + 1]);
        }
    }
}
