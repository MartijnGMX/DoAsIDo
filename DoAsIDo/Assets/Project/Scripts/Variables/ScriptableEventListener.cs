using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventListener : MonoBehaviour {
    public UnityEvent onEventCalled;
    public ScriptableEvent listenToEvent;

    private void Start() {
        listenToEvent.eventTriggered += EventCalled;
    }

    private void OnDestroy() {
        listenToEvent.eventTriggered -= EventCalled;
    }

    private void EventCalled() {
        onEventCalled.Invoke();
    }
}
