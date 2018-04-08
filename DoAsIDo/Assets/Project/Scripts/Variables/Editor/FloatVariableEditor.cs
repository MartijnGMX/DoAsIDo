using UnityEditor;

namespace IvoryLake.Variables
{
	[CustomEditor(typeof(FloatValue))]
	public class FloatVariableEditor : Editor {

		public override void OnInspectorGUI() {
			FloatValue f = (FloatValue)target;
			EditorGUI.BeginChangeCheck();

			EditorGUILayout.LabelField("Description:");
			f.displayName = EditorGUILayout.TextArea(f.displayName);

			f.useLimits = EditorGUILayout.Toggle("Limit value?", f.useLimits);
			if (f.useLimits) {
				f.minValue = EditorGUILayout.FloatField("Min", f.minValue);
				f.maxValue = EditorGUILayout.FloatField("Max", f.maxValue);
				f.Value = EditorGUILayout.Slider("Value", f.Value, f.minValue, f.maxValue);
			} else {
				f.Value = EditorGUILayout.FloatField("Value", f.Value);
			}
				
			f.modStep = EditorGUILayout.FloatField("Stepsize when incrementing/decrementing:", f.modStep);

			f.applyDefaultOnStartup = EditorGUILayout.Toggle("Use default value at startup?", f.applyDefaultOnStartup);
			if(f.applyDefaultOnStartup) {
				f.defaultValue = EditorGUILayout.FloatField("Default value", f.defaultValue);
			}
			if (EditorGUI.EndChangeCheck()) {
				EditorUtility.SetDirty(f);
			}
		}
	}
}
