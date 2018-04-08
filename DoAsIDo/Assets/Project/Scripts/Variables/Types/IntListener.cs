using System;
using UnityEngine.Events;

[Serializable]
public class OnChangedInt : UnityEvent<int> { }

public class IntListener : EventVariableListener {

    public OnChangedInt onChangedInt;
    public IntValue value;

    private void OnEnable() {
        value.onValueChanged += OnValueChanged;
        if (applyValueOnEnable)
            OnValueChanged(value.Value);
    }

    private void OnDisable() {
        value.onValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value) {
        onChanged.Invoke();
        onChangedInt.Invoke(value);
    }
}
