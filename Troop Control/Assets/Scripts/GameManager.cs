using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnitManager _unitManager;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private UIController _uiController;
    [SerializeField] private SpawnHandler _spawnHandler;
    private void Awake()
    {
        _unitManager.Initialize();
        _cameraController.Initialize();
        _spawnHandler.Initialize();
        _uiController.OnSpeedChanged += UpdateSpeed;
        _uiController.OnTargetDistanceChanged += UpdateTargetDistance;
        _uiController.OnButtonDown += SelectUnitButton;

    }
    
    public void UpdateSpeed(int speed)
    {
        _unitManager.SetAgentsSpeed(speed);
    }

    public void UpdateTargetDistance(float distance)
    {
        _unitManager.SetAgentsTargetDistance(distance);
    }

    public void SelectUnitButton(int select)
    {
        if (select == 0)
            _unitManager.SetDefault();
        if(select == 1)
            _unitManager.SelectAll(_uiController.Speed);
    }
}
