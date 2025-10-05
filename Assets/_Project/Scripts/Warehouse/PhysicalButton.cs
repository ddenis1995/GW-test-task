using System;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;


public class PhysicalButton : MonoBehaviour
    , IColliderEventPressEnterHandler
    , IColliderEventPressExitHandler

{
    public enum Directions
    {
        Forward,
        Back,
        Up,
        Down,
        Left,
        Right
    }
    
    [SerializeField] private Directions _buttonDirection;

    public event Action<Directions> OnButtonPressed;
    public event Action<Directions> OnButtonReleased;
    
    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        OnButtonPressed?.Invoke(_buttonDirection);
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        OnButtonReleased?.Invoke(_buttonDirection);
    }
}