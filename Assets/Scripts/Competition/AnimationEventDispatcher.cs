using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityAnimationEvent : UnityEvent<string> { };
public class AnimationEventDispatcher : MonoBehaviour
{
    public UnityAnimationEvent OnAnimationComplete;
    public void TriggerOnAnimationComplete(string name)
    {
        Debug.Log($"{name} animation complete.");
        OnAnimationComplete?.Invoke(name);
    }
}