using UnityEngine;

[CreateAssetMenu]
public class IntValue : VariableObject<int> {
    public int modStep;
    public int defaultValue;
    private int _value;
    public int Value {
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
	public int minValue;
	public int maxValue;

    public override void ResetToDefault() {
        _value = defaultValue;
    }

    private void Awake() {
        ResetToDefault();
    }
}
