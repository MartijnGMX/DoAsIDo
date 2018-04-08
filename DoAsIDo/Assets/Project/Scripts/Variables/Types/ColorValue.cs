using UnityEngine;

[CreateAssetMenu]
public class ColorValue : VariableObject<Color> {
	public Color defaultValue;
	private Color _value;
	public Color Value {
		get {
			return _value;
		}
		set {
			if (_value != value) {
				_value = value;
				if (onValueChanged != null)
					onValueChanged(_value);
			}
		}
	}
		
	public override void ResetToDefault() {
		_value = defaultValue;
	}

	private void Awake() {
		ResetToDefault();
	}
}
