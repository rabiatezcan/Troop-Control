using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public event Action<int> OnSpeedChanged;
    public event Action<float> OnTargetDistanceChanged;
    public event Action<int> OnButtonDown; 
    [SerializeField] private InputField _speedTxt;
    [SerializeField] private InputField _targetDistanceTxt;
    private int _speed;
    private float _targetDistance; 
    public int Speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
            OnSpeedChanged?.Invoke(_speed);
        }
    }

    public float TargetDistance
    {
        get => _targetDistance;
        set
        {
            _targetDistance = value;
            OnTargetDistanceChanged?.Invoke(_targetDistance);
        }
    }
    public void UpdateSpeedValue()
    {
        Speed = Int32.Parse(_speedTxt.text);
    }

    public void UpdateTargetDistanceValue()
    {
        TargetDistance = Int32.Parse(_targetDistanceTxt.text);
    }

    public void SelectButton(int select)
    {
        OnButtonDown?.Invoke(select);
    }


}
