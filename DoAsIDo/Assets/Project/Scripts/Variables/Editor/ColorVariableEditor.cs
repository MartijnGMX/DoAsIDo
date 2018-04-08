using UnityEditor;

namespace IvoryLake.Variables
{
	[CustomEditor(typeof(ColorValue))]
	public class ColorVariableEditor : Editor {

		public override void OnInspectorGUI() {
			ColorValue f = (ColorValue)target;
			EditorGUI.BeginChangeCheck();

			EditorGUILayout.LabelField("Description:");
			f.displayName = EditorGUILayout.TextArea(f.displayName);

			f.Value = EditorGUILayout.ColorField("Value", f.Value);

			f.applyDefaultOnStartup = EditorGUILayout.Toggle("Use default value at startup?", f.applyDefaultOnStartup);
			if(f.applyDefaultOnStartup) {
				f.defaultValue = EditorGUILayout.ColorField("Default value", f.defaultValue);
			}
			if (EditorGUI.EndChangeCheck()) {
				EditorUtility.SetDirty(f);
			}
		}
	}
}
