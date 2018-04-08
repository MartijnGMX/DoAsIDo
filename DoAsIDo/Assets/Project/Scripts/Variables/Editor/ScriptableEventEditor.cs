using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScriptableEvent))]
public class ScriptableEventEditor : Editor {

    public override void OnInspectorGUI() {
        ScriptableEvent eventScript = (ScriptableEvent)target;

		EditorGUILayout.LabelField("Description:");
		eventScript.displayName = EditorGUILayout.TextArea(eventScript.displayName);
        
		if (GUILayout.Button("Trigger Event")) {
            eventScript.TriggerEvent();
        }
        DrawDefaultInspector();
    }
}
