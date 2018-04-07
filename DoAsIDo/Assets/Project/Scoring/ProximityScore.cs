using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityScore : MonoBehaviour {
    [Range(0f, 1f)]
    public float score = 0f;
    public Transform objectA;
    public Transform objectB;

    public ProximityScoreComputer algorithm;
    
	// Use this for initialization
	void OnEnable() {
        score = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        score = 0f;
		if (objectA && objectB)
        {
            if (objectA.gameObject.activeInHierarchy && objectB.gameObject.activeInHierarchy)
            {
                score = algorithm.Compute(objectA, objectB);
            } 
        }
	}
}
