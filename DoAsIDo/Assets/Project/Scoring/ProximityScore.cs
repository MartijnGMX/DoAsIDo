using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityScore : MonoBehaviour {
    public FloatValue score;
    public Transform objectA;
    public Transform objectB;

    public ProximityScoreComputer algorithm;
    
	// Update is called once per frame
	void Update () {
        if (objectA && objectB)
        {
            if (objectA.gameObject.activeInHierarchy && objectB.gameObject.activeInHierarchy)
            {
                score.Value = algorithm.Compute(objectA, objectB);
            } 
        }
	}
}
