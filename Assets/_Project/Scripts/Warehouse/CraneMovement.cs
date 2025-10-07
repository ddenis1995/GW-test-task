using System;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private Axis _axis;
    [SerializeField] private Collider _workZoneBoundaries;
    
    private enum Axis
    {
        X,
        Y,
        Z
    }

    private Vector3 _direction;

    private BaseCraneController _craneController;

    private void Awake()
    {
        _craneController = FindObjectOfType<BaseCraneController>();
        switch (_axis)
        {
            case Axis.Z:
                _craneController.OnForwardEnter.AddListener(StartMovingForward);
                _craneController.OnForwardExit.AddListener(StopMoving);
                _craneController.OnBackEnter.AddListener(StartMovingBack);
                _craneController.OnBackExit.AddListener(StopMoving);
                break;
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
        if (IsWithinBoundaries())
        {
            transform.Translate(_direction * (_speed * Time.deltaTime));
        }
    }

    private bool IsWithinBoundaries()
    {
        var zoneCenter = _workZoneBoundaries.bounds.center;
        var zoneExtents = _workZoneBoundaries.bounds.extents;
        var futureposition = transform.position + _direction;

        switch (_axis)
        {
            case Axis.X:
                return futureposition.x < zoneCenter.x + zoneExtents.x &&
                       futureposition.x > zoneCenter.x - zoneExtents.x;
            case Axis.Y:
                return futureposition.y < zoneCenter.y + zoneExtents.y &&
                       futureposition.y > zoneCenter.y - zoneExtents.y;
            case Axis.Z:
                return futureposition.z < zoneCenter.z + zoneExtents.z &&
                       futureposition.z > zoneCenter.z - zoneExtents.z;
            default:
                throw new ArgumentOutOfRangeException();
        }
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