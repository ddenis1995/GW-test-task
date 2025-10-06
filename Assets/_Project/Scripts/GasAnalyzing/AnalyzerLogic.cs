using System;
using UnityEngine;

public class AnalyzerLogic : MonoBehaviour
{
    private GameObject[] _dangerZones;
    private bool _isOn = false;
    private bool _isPressed;
    private float _timer;

    [SerializeField] private Transform _sensor;
    [SerializeField] private AnalyzerButton _button;
    [SerializeField] private float _animationTimer = 3;
    
    public float AnimationTimer => _animationTimer;

    public event Action OnStartedActivation;
    public event Action OnActivated;
    public event Action OnStartedDeactivation;
    public event Action OnDeactivated;
    public event Action<float> OnDistanceChanged;


    private void Awake()
    {
        _dangerZones = GameObject.FindGameObjectsWithTag("DangerZone");
        _timer = _animationTimer;
        _button.OnButtonPress.AddListener(OnPress);
        _button.OnButtonRelease.AddListener(OnRelease);
    }

    private void OnPress()
    {
        if (_isOn)
        {
            OnStartedDeactivation?.Invoke();
        }
        else
        {
            OnStartedActivation?.Invoke();
        }

        _isPressed = true;
    }

    private void OnRelease()
    {
        _timer = _animationTimer;
        if (_isOn)
        {
            OnActivated?.Invoke();
        }
        else
        {
            OnDeactivated?.Invoke();
            OnDistanceChanged?.Invoke(0f);
        }

        _isPressed = false;
    }


    private void Update()
    {
        if (_isOn)
        {
            CalculateDistanceToNearestZone();
            if (!_isPressed) return;
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                _timer = _animationTimer;
                OnDeactivated?.Invoke();
                OnDistanceChanged?.Invoke(0f);
                _isOn = false;
                _isPressed = false;
            }
        }
        else
        {
            if (!_isPressed) return;
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                _timer = _animationTimer;
                OnActivated?.Invoke();
                _isOn = true;
                _isPressed = false;
            }
        }
    }

    private void CalculateDistanceToNearestZone()
    {
        float minDistance = Mathf.Infinity;

        foreach (GameObject zone in _dangerZones)
        {
            float distance = Vector3.Distance(_sensor.position, zone.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                OnDistanceChanged?.Invoke(minDistance);
            }
        }
    }
}