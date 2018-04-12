using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyEmissiveBasedOnFloat: FloatListener_Curved {
    public Material material;

    [ColorUsage(true, true)]
    public Color baseColor;
    [ColorUsage(true, true)]
    public Color lerpedColor;

    [Range(0,10f)]
    public float hdrValue = 1f;

    public string ColorName = "_EmissionColor"; // name of the shader property to adjust

    // Use this for initialization
    void Start () {
	    if (material== null)
        {
            material = GetComponent<Renderer>().material;
        }	
	}

    protected override void OnValueChanged(float value)
    {
        base.OnValueChanged(value);
        hdrValue = outPutAfterCurve;
        lerpedColor = baseColor * hdrValue;
        
        material.SetColor(ColorName, lerpedColor);
    }
}
