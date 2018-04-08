using UnityEngine;

public abstract class VariableObject<T> : ScriptableObject {
    public string displayName;
	public bool applyDefaultOnStartup;

	protected virtual void OnEnable(){
		if(applyDefaultOnStartup) {
			ResetToDefault();
			// we might not have all listeners yet,
			// but they can use callFirstTime to use the value that is set 
			// when we start with the Update() routines
		}
	}

    public delegate void OnValueChanged(T value);
    public OnValueChanged onValueChanged;

    public abstract void ResetToDefault();
}
