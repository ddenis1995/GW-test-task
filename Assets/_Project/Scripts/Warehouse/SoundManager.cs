using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _xAxisMovement;
    [SerializeField] private AudioClip _yAxisMovement;
    [SerializeField] private AudioClip _zAxisMovement;
    [SerializeField] private AudioSource _XaudioSource;
    [SerializeField] private AudioSource _YaudioSource;
    [SerializeField] private AudioSource _ZaudioSource;

    private BaseCraneController _craneController;

    private void Awake()
    {
        _craneController = FindObjectOfType<BaseCraneController>();
        _craneController.OnForwardEnter.AddListener(StartZSound);
        _craneController.OnForwardExit.AddListener(StopSound);
        _craneController.OnBackEnter.AddListener(StartZSound);
        _craneController.OnBackExit.AddListener(StopSound);
        _craneController.OnRightEnter.AddListener(StartXSound);
        _craneController.OnRightExit.AddListener(StopSound);
        _craneController.OnLeftEnter.AddListener(StartXSound);
        _craneController.OnLeftExit.AddListener(StopSound);
        _craneController.OnUpEnter.AddListener(StartYSound);
        _craneController.OnUpExit.AddListener(StopSound);
        _craneController.OnDownEnter.AddListener(StartYSound);
        _craneController.OnDownExit.AddListener(StopSound);
        
        _XaudioSource.clip = _xAxisMovement;
        _YaudioSource.clip = _yAxisMovement;
        _ZaudioSource.clip = _zAxisMovement;
    }

    private void StartXSound()
    {
        _XaudioSource.Play();
    }

    private void StartYSound()
    {
        _YaudioSource.Play();
    }

    private void StartZSound()
    {
        _ZaudioSource.Play();
    }

    private void StopSound()
    {
        _XaudioSource.Stop();
        _YaudioSource.Stop();
        _ZaudioSource.Stop();
    }
}