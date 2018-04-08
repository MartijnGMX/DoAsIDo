using UnityEngine;

[CreateAssetMenu]
public class FloatValue : VariableObject<float> {
    public float modStep;
    public float defaultValue;
    private float _value;
    public float Value {
        get {
            return _value;
        }
        set {
			if (_value != value) {
				// TBD: apply min/max?
                _value = value;
                if (onValueChanged != null)
                    onValueChanged(_value);
            }
        }
    }

	public bool useLimits;
	public float minValue;
	public float maxValue;

    public override void ResetToDefault() {
        _value = defaultValue;
    }

    private void Awake() {
        ResetToDefault();
    }
}
