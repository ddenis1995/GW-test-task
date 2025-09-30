using System.Collections;
using System.Collections.Generic;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using UnityEngine;

public class BaseButton : MonoBehaviour
    , IColliderEventPressEnterHandler
    , IColliderEventPressExitHandler
{
    
    
    public Transform buttonObject;
    public Vector3 buttonDownDisplacement;
    
    private ColliderButtonEventData.InputButton m_activeButton = ColliderButtonEventData.InputButton.Trigger;

    private HashSet<ColliderButtonEventData> pressingEvents = new HashSet<ColliderButtonEventData>();

    public ColliderButtonEventData.InputButton activeButton { get { return m_activeButton; } set { m_activeButton = value; } }
    
    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        if (eventData.button == m_activeButton && pressingEvents.Add(eventData) && pressingEvents.Count == 1)
        {
            buttonObject.localPosition += buttonDownDisplacement;
            throw new System.NotImplementedException();
        }
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        if (pressingEvents.Remove(eventData) && pressingEvents.Count == 0)
        {
            buttonObject.localPosition -= buttonDownDisplacement;
            throw new System.NotImplementedException();
        }
    }
}
