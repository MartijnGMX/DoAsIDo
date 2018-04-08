using System;
using UnityEngine.Events;
using UnityEngine;

[Serializable]
public class FloatListener_Curved : FloatListener {
    public AnimationCurve curve;
    public float outPutAfterCurve;

    protected override void OnValueChanged(float value) {
        outPutAfterCurve = curve.Evaluate(value);
        onChanged.Invoke();
        onChangedFloat.Invoke(outPutAfterCurve);
    }
}
