using System;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    private enum Axis
    {
        X,
        Y,
        Z
    }

    [SerializeField] private float _speed;
    [SerializeField] private Axis _axis;

    private Vector3 _direction;

    private BaseCraneController _craneController;

    private void Awake()
    {
        _craneController = FindObjectOfType<BaseCraneController>();
        if (_craneController != null)
        {
            Debug.Log("Controller located");
        }
        switch (_axis)
        {
            case Axis.Z:
            {
                _craneController.OnForwardEnter.AddListener(StartMovingForward);
                _craneController.OnForwardExit.AddListener(StopMoving);
                _craneController.OnBackEnter.AddListener(StartMovingBack);
                _craneController.OnBackExit.AddListener(StopMoving);
                break;
            }
            case Axis.X:
                _craneController.OnRightEnter.AddListener(StartMovingRight);
                _craneController.OnRightExit.AddListener(StopMoving);
                _craneController.OnLeftEnter.AddListener(StartMovingLeft);
                _craneController.OnLeftExit.AddListener(StopMoving);
                break;
            case Axis.Y:
                _craneController.OnUpEnter.AddListener(StartMovingUp);
                _craneController.OnUpExit.AddListener(StopMoving);
                _craneController.OnDownEnter.AddListener(StartMovingDown);
                _craneController.OnDownExit.AddListener(StopMoving);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private void StopMoving()
    {
        _direction = Vector3.zero;
    }

    private void StartMovingForward()
    {
        _direction = Vector3.forward;
        Debug.Log("Moving forward");
    }

    private void StartMovingBack()
    {
        _direction = Vector3.back;
    }
    private void StartMovingRight()
    {
        _direction = Vector3.right;
    }

    private void StartMovingLeft()
    {
        _direction = Vector3.left;
    }

    private void StartMovingUp()
    {
        _direction = Vector3.up;
    }

    private void StartMovingDown()
    {
        _direction = Vector3.down;
    }



    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    
    private void OnDestroy()
    {
        switch (_axis)
        {
            case Axis.Z:
            {
                _craneController.OnForwardEnter.RemoveListener(StartMovingForward);
                _craneController.OnForwardExit.RemoveListener(StopMoving);
                _craneController.OnBackEnter.RemoveListener(StartMovingBack);
                _craneController.OnBackExit.RemoveListener(StopMoving);
                break;
            }
            case Axis.X:
            {
                _craneController.OnRightEnter.RemoveListener(StartMovingRight);
                _craneController.OnRightExit.RemoveListener(StopMoving);
                _craneController.OnLeftEnter.RemoveListener(StartMovingLeft);
                _craneController.OnLeftExit.RemoveListener(StopMoving);
                break;
            }

            case Axis.Y:
            {
            
                _craneController.OnUpEnter.RemoveListener(StartMovingUp);
                _craneController.OnUpExit.RemoveListener(StopMoving);
                _craneController.OnDownEnter.RemoveListener(StartMovingDown);
                _craneController.OnDownExit.RemoveListener(StopMoving);
                break;
        }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}