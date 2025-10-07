using System;
using UnityEngine;

public class AnalyzerLogic : MonoBehaviour
{
    private enum HandheldStates
    {
        JustAnalyzer,
        JustRod,
        Both,
        None
    }

    private HandheldStates _inHand;
    private GameObject[] _dangerZones;
    private bool _isOn = false;
    private bool _isPressed;
    private float _timer;

    [SerializeField] private Transform _sensor;
    [SerializeField] private AnalyzerButton _button;
    [SerializeField] private float _animationTimer = 3;
    [SerializeField] private UiManager _uiManager;

    public float AnimationTimer => _animationTimer;

    public event Action OnStartedActivation;
    public event Action OnActivated;
    public event Action OnStartedDeactivation;
    public event Action OnDeactivated;
    public event Action<float> OnDistanceChanged;


    private void Awake()
    {
        _inHand = HandheldStates.None;
        _uiManager.UpdateText(0);
        _dangerZones = GameObject.FindGameObjectsWithTag("DangerZone");
        _timer = _animationTimer;
        _button.OnButtonPress.AddListener(OnPress);
        _button.OnButtonRelease.AddListener(OnRelease);
    }

    private void OnPress()
    {
        if (_isOn)
        {
            _uiManager.UpdateText(3);
            OnStartedDeactivation?.Invoke();
        }
        else
        {
            _uiManager.UpdateText(1);
            OnStartedActivation?.Invoke();
        }

        _isPressed = true;
    }

    private void OnRelease()
    {
        _timer = _animationTimer;
        if (_isOn)
        {
            switch (_inHand)
            {
                case HandheldStates.JustAnalyzer:
                    _uiManager.UpdateText(2);
                    break;
                case HandheldStates.JustRod:
                    _uiManager.UpdateText(0);
                    break;
                case HandheldStates.Both:
                    _uiManager.ClearText();
                    break;
                case HandheldStates.None:
                    _uiManager.UpdateText(0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            OnActivated?.Invoke();
        }
        else
        {
            switch (_inHand)
            {
                case HandheldStates.JustAnalyzer:
                    _uiManager.UpdateText(1);
                    break;
                case HandheldStates.JustRod:
                    _uiManager.UpdateText(0);
                    break;
                case HandheldStates.Both:
                    _uiManager.ClearText();
                    break;
                case HandheldStates.None:
                    _uiManager.UpdateText(0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

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

    public void UpdateAnalyzerState()
    {
        switch (_inHand)
        {
            case HandheldStates.JustAnalyzer:
                _inHand = HandheldStates.None;
                if (_isOn)
                    _uiManager.UpdateText(0);
                else
                    _uiManager.UpdateText(0);
                break;
            
            case HandheldStates.JustRod:
                _inHand = HandheldStates.Both;
                if (_isOn)
                    _uiManager.ClearText();
                else
                    _uiManager.UpdateText(1);
                break;
            
            case HandheldStates.Both:
                _inHand = HandheldStates.JustRod;
                if (_isOn)
                    _uiManager.UpdateText(0);
                else
                    _uiManager.UpdateText(0);
                break;
            
            case HandheldStates.None:
                _inHand = HandheldStates.JustAnalyzer;
                if (_isOn)
                    _uiManager.UpdateText(2);
                else
                    _uiManager.UpdateText(1);
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void UpdateRodState()
    {
        switch (_inHand)
        {
            case HandheldStates.JustAnalyzer:
                _inHand = HandheldStates.Both;
                if (_isOn)
                    _uiManager.ClearText();
                else
                    _uiManager.UpdateText(1);
                break;
            
            case HandheldStates.JustRod:
                _inHand = HandheldStates.None;
                if (_isOn)
                    _uiManager.UpdateText(0);
                else
                    _uiManager.UpdateText(0);
                break;
            
            case HandheldStates.Both:
                _inHand = HandheldStates.JustAnalyzer;
                if (_isOn)
                    _uiManager.UpdateText(2);
                else
                    _uiManager.UpdateText(1);
                break;
            
            case HandheldStates.None:
                _inHand = HandheldStates.JustRod;
                if (_isOn)
                    _uiManager.UpdateText(0);
                else
                    _uiManager.UpdateText(0);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}