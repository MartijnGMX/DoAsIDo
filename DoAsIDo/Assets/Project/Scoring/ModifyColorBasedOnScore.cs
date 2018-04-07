using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyColorBasedOnScore : MonoBehaviour {
    public ProximityScore score;
    public Material material;

    public Color score0color;
    public Color score1color;
    public Color lerpedColor;

    public string ColorName = "_TintColor"; // name of the shader property to adjust

    // Use this for initialization
    void Start () {
	    if (material== null)
        {
            material = GetComponent<Renderer>().material;
        }	
	}
	
	// Update is called once per frame
	void Update () {
        if (score)
        {
            lerpedColor = Color.Lerp(score0color, score1color, score.score);
            material.SetColor(ColorName, lerpedColor);
        }
	}
}
