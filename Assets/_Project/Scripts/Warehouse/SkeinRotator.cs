using System;
using UnityEngine;

public class SkeinRotator : MonoBehaviour
{
    private enum Axis
    {
        X,
        Y,
        Z
    }

    [SerializeField] private Axis _axis;
    [SerializeField] private float _rotationSpeed;
    
    private BaseCraneController _craneController;
    private bool _isRotating;

    private void Awake()
    {
        _isRotating = false;
        _craneController = FindObjectOfType<BaseCraneController>();
        switch (_axis)
        {
            case Axis.Z:
                _craneController.OnForwardEnter.AddListener(StartRotating);
                _craneController.OnForwardExit.AddListener(StopRotating);
                _craneController.OnBackEnter.AddListener(StartRotating);
                _craneController.OnBackExit.AddListener(StopRotating);
                break;
            case Axis.X:
                _craneController.OnRightEnter.AddListener(StartRotating);
                _craneController.OnRightExit.AddListener(StopRotating);
                _craneController.OnLeftEnter.AddListener(StartRotating);
                _craneController.OnLeftExit.AddListener(StopRotating);
                break;
            case Axis.Y:
                _craneController.OnUpEnter.AddListener(StartRotating);
                _craneController.OnUpExit.AddListener(StopRotating);
                _craneController.OnDownEnter.AddListener(StartRotating);
                _craneController.OnDownExit.AddListener(StopRotating);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Update()
    {
        if (_isRotating)
        {
            Debug.Log("rotating");
            transform.Rotate(Vector3.right, _rotationSpeed * Time.deltaTime );
        }
    }

    private void StartRotating()
    {
        Debug.Log("Starting rotation");
        _isRotating = true;
    }

    private void StopRotating()
    {
        _isRotating = false;
    }
}
