using System;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;


public class AnalyzerButton : MonoBehaviour
    , IColliderEventPressEnterHandler
    , IColliderEventPressExitHandler

{
    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        throw new NotImplementedException();
    }
}