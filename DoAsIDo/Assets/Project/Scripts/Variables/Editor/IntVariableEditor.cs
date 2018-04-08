using UnityEditor;

namespace IvoryLake.Variables
{
	[CustomEditor(typeof(IntValue))]
	public class IntVariableEditor : Editor {

		public override void OnInspectorGUI() {
			IntValue f = (IntValue)target;
			EditorGUI.BeginChangeCheck();

			EditorGUILayout.LabelField("Description:");
			f.displayName = EditorGUILayout.TextArea(f.displayName);

			f.useLimits = EditorGUILayout.Toggle("Limit value?", f.useLimits);
			if (f.useLimits) {
				f.minValue = EditorGUILayout.IntField("Min", f.minValue);
				f.maxValue = EditorGUILayout.IntField("Max", f.maxValue);
				f.Value = EditorGUILayout.IntSlider("Value", f.Value, f.minValue, f.maxValue);
			} else {
				f.Value = EditorGUILayout.IntField("Value", f.Value);
			}

			f.modStep = EditorGUILayout.IntField("Stepsize when incrementing/decrementing:", f.modStep);

			f.applyDefaultOnStartup = EditorGUILayout.Toggle("Use default value at startup?", f.applyDefaultOnStartup);
			if(f.applyDefaultOnStartup) {
				f.defaultValue = EditorGUILayout.IntField("Default value", f.defaultValue);
			}
			if (EditorGUI.EndChangeCheck()) {
				EditorUtility.SetDirty(f);
			}
		}
	}
}
