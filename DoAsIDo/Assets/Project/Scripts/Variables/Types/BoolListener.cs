using System;
using UnityEngine.Events;

[Serializable]
public class OnChangedBool : UnityEvent<bool> { }

public class BoolListener : EventVariableListener {

    public OnChangedBool onChangedBool;
    
    public BoolValue value;

    private void OnEnable() {
        value.onValueChanged += OnValueChanged;
        if (applyValueOnEnable)
            OnValueChanged(value.Value);
    }

    private void OnDisable() {
        value.onValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(bool value) {
        onChanged.Invoke();
        onChangedBool.Invoke(value);
    }
}
