using UnityEngine;

[CreateAssetMenu]
public class ScriptableEvent : ScriptableObject {

    public string displayName;

    public delegate void EventTriggered();
    public EventTriggered eventTriggered;

    public void TriggerEvent() {
        if (eventTriggered != null)
            eventTriggered();
    }
}
