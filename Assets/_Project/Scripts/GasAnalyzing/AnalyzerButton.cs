using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;
using UnityEngine.Events;


public class AnalyzerButton : MonoBehaviour
    , IColliderEventPressEnterHandler
    , IColliderEventPressExitHandler

{
    [HideInInspector] public UnityEvent OnButtonPress;
    [HideInInspector] public UnityEvent OnButtonRelease;

    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        OnButtonPress?.Invoke();
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        OnButtonRelease?.Invoke();
    }
}