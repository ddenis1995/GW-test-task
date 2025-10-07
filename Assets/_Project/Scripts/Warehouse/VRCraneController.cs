using System;
using System.Collections.Generic;
using UnityEngine;

public class VRCraneController : BaseCraneController
{
    [SerializeField] private List<PhysicalButton> _buttons;
    [SerializeField] private UiManager _uiManager;
    
    private enum HandheldStates
    {
        None,
        Controller
    }

    private HandheldStates _inHand; 

    private void Awake()
    {
        _inHand = HandheldStates.None;
        _uiManager.UpdateText(0);
        foreach (PhysicalButton button in _buttons)
        {
            button.OnButtonPressed += HandleButtonPressed;
            button.OnButtonReleased += HandleButtonReleased;
        }
    }

    private void HandleButtonReleased(PhysicalButton.Directions direction)
    {
        switch (direction)
        {
            case PhysicalButton.Directions.Forward:
                InvokeForwardExit();
                break;
            case PhysicalButton.Directions.Back:
                InvokeBackExit();
                break;
            case PhysicalButton.Directions.Up:
                InvokeUpExit();
                break;
            case PhysicalButton.Directions.Down:
                InvokeDownExit();
                break;
            case PhysicalButton.Directions.Left:
                InvokeLeftExit();
                break;
            case PhysicalButton.Directions.Right:
                InvokeRightExit();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    private void HandleButtonPressed(PhysicalButton.Directions direction)
    {
        switch (direction)
        {
            case PhysicalButton.Directions.Forward:
                InvokeForwardEnter();
                break;
            case PhysicalButton.Directions.Back:
                InvokeBackEnter();
                break;
            case PhysicalButton.Directions.Up:
                InvokeUpEnter();
                break;
            case PhysicalButton.Directions.Down:
                InvokeDownEnter();
                break;
            case PhysicalButton.Directions.Left:
                InvokeLeftEnter();
                break;
            case PhysicalButton.Directions.Right:
                InvokeRightEnter();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    public void UpdateControllerState()
    {
        switch (_inHand)
        {
            case HandheldStates.None:
                _inHand = HandheldStates.Controller;
                _uiManager.UpdateText(1);
                break;
            case HandheldStates.Controller:
                _inHand = HandheldStates.None;
                _uiManager.UpdateText(0);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}