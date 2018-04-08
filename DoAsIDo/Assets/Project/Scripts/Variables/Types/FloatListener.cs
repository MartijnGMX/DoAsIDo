using System;
using UnityEngine.Events;

[Serializable]
public class OnChangedFloat : UnityEvent<float> { }

public class FloatListener : EventVariableListener {

    public OnChangedFloat onChangedFloat;
    public FloatValue value;

    private void OnEnable() {
        value.onValueChanged += OnValueChanged;
        if (applyValueOnEnable)
            OnValueChanged(value.Value);
    }

    private void OnDisable() {
        value.onValueChanged -= OnValueChanged;
    }

    protected virtual void OnValueChanged(float value) {
        onChanged.Invoke();
        onChangedFloat.Invoke(value);
    }
}
