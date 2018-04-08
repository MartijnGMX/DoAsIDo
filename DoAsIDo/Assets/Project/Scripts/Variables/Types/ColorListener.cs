using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OnChangedColor : UnityEvent<Color> { }

public class ColorListener : EventVariableListener {

	public OnChangedColor onChangedColor;

	public ColorValue value;

	private void OnEnable() {
		value.onValueChanged += OnValueChanged;
		if (applyValueOnEnable)
			OnValueChanged(value.Value);
	}

	private void OnDisable() {
		value.onValueChanged -= OnValueChanged;
	}

	private void OnValueChanged(Color value) {
		onChanged.Invoke();
		onChangedColor.Invoke(value);
	}
}
