using UnityEngine;

[CreateAssetMenu]
public class BoolValue : VariableObject<bool> {
    private bool _value;
    public bool defaultValue;
    public bool Value {
        get {
            return _value;
        } set {
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

