using UnityEditor;

namespace IvoryLake.Variables
{
	[CustomEditor(typeof(BoolValue))]
	public class BoolValueEditor : Editor {
		public override void OnInspectorGUI() {
			BoolValue f = (BoolValue)target;
			EditorGUI.BeginChangeCheck();

			EditorGUILayout.LabelField("Description:");
			f.displayName = EditorGUILayout.TextArea(f.displayName);

			f.Value = EditorGUILayout.Toggle("Value", f.Value);

			f.applyDefaultOnStartup = EditorGUILayout.Toggle("Use default value at startup?", f.applyDefaultOnStartup);
			if(f.applyDefaultOnStartup) {
				f.defaultValue = EditorGUILayout.Toggle("Default value", f.defaultValue);
			}
			if (EditorGUI.EndChangeCheck()) {
				EditorUtility.SetDirty(f);
			}
		}
	}
}
