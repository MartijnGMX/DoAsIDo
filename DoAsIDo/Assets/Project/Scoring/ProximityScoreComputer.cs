using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProximityScoreComputer", menuName = "Proximity/ProximityScoreComputer")]
public class ProximityScoreComputer : ScriptableObject {

    // Return a score in [0..1]
    // 1 means objA and objB are very close to one another
    // 0 means they are too far apart
    public virtual float Compute(Transform objA, Transform objB)
    {
        return 0f;
    }
}
