using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyColorBasedOnFloat: FloatListener_Curved {
    public Material material;

    public Color colorAt0;
    public Color colorAt1;
    public Color lerpedColor;

    public string ColorName = "_TintColor"; // name of the shader property to adjust

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
        lerpedColor = Color.Lerp(colorAt0, colorAt1, outPutAfterCurve);
        material.SetColor(ColorName, lerpedColor);
    }
}
