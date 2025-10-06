using TMPro;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class DisplayManager : MonoBehaviour
{
    private enum DisplayStates
    {
        Off,
        TurningOn,
        On,
        TurningOff
    }

    private DisplayStates _state;
    private float _animationTime;
    private CanvasGroup _canvasGroup;

    [SerializeField] private TMP_Text _text;
    [SerializeField] private AnalyzerLogic _logic;


    private void Awake()
    {
        _text.text = "0.00";
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _animationTime = _logic.AnimationTimer;
        _logic.OnStartedActivation += StartTurnOnAnimation;
        _logic.OnActivated += StopTurnOnAnimation;
        _logic.OnStartedDeactivation += StartTurnOffAnimation;
        _logic.OnDeactivated += StopTurnOffAnimation;
        _logic.OnDistanceChanged += ShowDistance;
    }

    private void Update()
    {
        switch (_state)
        {
            case DisplayStates.TurningOn:
                if (_canvasGroup.alpha < 1)
                    _canvasGroup.alpha += Time.deltaTime/_animationTime;
                break;
            case DisplayStates.TurningOff:
                if (_canvasGroup.alpha > 0)
                    _canvasGroup.alpha -= Time.deltaTime/_animationTime;
                break;
            default:
                break;
        }
    }

    private void StartTurnOnAnimation()
    {
        _state = DisplayStates.TurningOn;
    }

    private void StopTurnOnAnimation()
    {
        _state = DisplayStates.On;
        _canvasGroup.alpha = 1;
    }

    private void StartTurnOffAnimation()
    {
        _state = DisplayStates.TurningOff;
    }

    private void StopTurnOffAnimation()
    {
        _state = DisplayStates.Off;
        _canvasGroup.alpha = 0;
    }

    private void ShowDistance(float distance)
    {
        _text.text = distance.ToString("0.00");
    }
}