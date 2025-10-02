using System;
using System.Collections.Generic;
using UnityEngine;

public class VRCraneController : BaseCraneController
{
    [SerializeField] private List<PhysicalButton> _buttons;

    private void Awake()
    {
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
}