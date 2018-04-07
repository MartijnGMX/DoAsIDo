using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProximityScoreComputer_PosOnly", menuName = "Proximity/ProximityScoreComputer_PosOnly")]
public class ProximityScoreComputer_PosOnly : ProximityScoreComputer
{
    // anything closer than this will get score of 1
    [Range(0f, 1f)]
    public float dist_inner = 0f;
    
    // anything further than this will get score of 0
    [Range(0f, 1f)]
    public float dist_outer = 1f;

    // Return a score in [0..1]
    // 1 means objA and objB are very close to one another
    // 0 means they are too far apart
    public override float Compute(Transform objA, Transform objB)
    {
        float d = Vector3.Distance(objA.transform.position, objB.transform.position);
        float s = Remap(d, dist_inner, dist_outer, 1f, 0f);
        s = Mathf.Clamp01(s);
        return s;
    }

    float Remap(float value, float fromRangeLow, float fromRangeHigh, float toRangeLow, float toRangeHigh)
    {
        return (value - fromRangeLow) / (fromRangeHigh - fromRangeLow) * (toRangeHigh - toRangeLow) + toRangeLow;
    }
}
