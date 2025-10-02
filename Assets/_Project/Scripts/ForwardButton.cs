using System;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections.Generic;
using UnityEngine;

public class ForwardButton : MonoBehaviour
    , IColliderEventPressEnterHandler
    , IColliderEventPressExitHandler
{
    public static event EventHandler OnForwardEnter;
    public static event EventHandler OnForwardExit;
    
    public Transform buttonObject;
    public Vector3 buttonDownDisplacement;

    [SerializeField]
    private ColliderButtonEventData.InputButton m_activeButton = ColliderButtonEventData.InputButton.Trigger;
    private HashSet<ColliderButtonEventData> pressingEvents = new HashSet<ColliderButtonEventData>();

    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        if (eventData.button == m_activeButton && pressingEvents.Add(eventData) && pressingEvents.Count == 1)
        {
            OnForwardEnter?.Invoke(this, EventArgs.Empty);
            buttonObject.localPosition += buttonDownDisplacement;
        }
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        if (pressingEvents.Remove(eventData) && pressingEvents.Count == 0)
        {
            OnForwardExit?.Invoke(this, EventArgs.Empty);
            buttonObject.localPosition -= buttonDownDisplacement;
        }
    }
}