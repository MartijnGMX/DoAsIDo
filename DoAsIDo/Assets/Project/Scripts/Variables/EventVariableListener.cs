using UnityEngine;
using UnityEngine.Events;

public abstract class EventVariableListener : MonoBehaviour {
    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent onChanged;
    public bool applyValueOnEnable;
}