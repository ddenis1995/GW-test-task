using UnityEngine;
using UnityEngine.Events;

public abstract class BaseCraneController : MonoBehaviour
{
    [HideInInspector] public UnityEvent OnForwardEnter;
    [HideInInspector] public UnityEvent OnForwardExit;
    [HideInInspector] public UnityEvent OnBackEnter;
    [HideInInspector] public UnityEvent OnBackExit;
    [HideInInspector] public UnityEvent OnUpEnter;
    [HideInInspector] public UnityEvent OnUpExit;
    [HideInInspector] public UnityEvent OnDownEnter;
    [HideInInspector] public UnityEvent OnDownExit;
    [HideInInspector] public UnityEvent OnLeftEnter;
    [HideInInspector] public UnityEvent OnLeftExit;
    [HideInInspector] public UnityEvent OnRightEnter;
    [HideInInspector] public UnityEvent OnRightExit;


protected void InvokeForwardEnter()
    {
        OnForwardEnter?.Invoke();
    }

    protected void InvokeForwardExit()
    {
        OnForwardExit?.Invoke();
    }

    protected void InvokeBackEnter()
    {
        OnBackEnter?.Invoke();
    }

    protected void InvokeBackExit()
    {
        OnBackExit?.Invoke();
    }

    protected void InvokeUpEnter()
    {
        OnUpEnter?.Invoke();
    }

    protected void InvokeUpExit()
    {
        OnUpExit?.Invoke();
    }

    protected void InvokeDownEnter()
    {
        OnDownEnter?.Invoke();
    }

    protected void InvokeDownExit()
    {
        OnDownExit?.Invoke();
    }

    protected void InvokeLeftEnter()
    {
        OnLeftEnter?.Invoke();
    }

    protected void InvokeLeftExit()
    {
        OnLeftExit?.Invoke();
    }

    protected void InvokeRightEnter()
    {
        OnRightEnter?.Invoke();
    }

    protected void InvokeRightExit()
    {
        OnRightExit?.Invoke();
    }
}