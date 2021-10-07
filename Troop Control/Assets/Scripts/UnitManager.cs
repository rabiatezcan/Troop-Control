using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitManager : ControllerBase
{
    [SerializeField] private InputHandler _inputHandler;
    private List<UnitController> _units;
    private List<UnitController> _selectedUnits;

    public override void Initialize()
    {
        _inputHandler.OnUnitSelected += AddAgent;
        _inputHandler.OnUnitSelectedWithDrag += UnitBoxSelection;
        _inputHandler.OnTargetSelectedOrMoved += SetAgentsTargetTransform;
        _inputHandler.OnGapSelected += SetDefault;
        _units = new List<UnitController>();
        _selectedUnits = new List<UnitController>();
        _units.ForEach(unit => unit.Initialize());
    }

    public void SetAgentsSpeed(int speed)
    {
        _selectedUnits.ForEach(unit => unit.SetSpeed(speed));
    }

    public void SetAgentsTargetDistance(float distance)
    {
        _selectedUnits.ForEach(unit => unit.TargetDistance = distance);
    }

    public void SetAgentsTargetTransform(Target target)
    {
        if (_selectedUnits != null)
        {
            _selectedUnits.ForEach(unit => unit.TargetTransform = target.transform);
            ShowCounts();
            SetDefault();
        }
    }

    public void AddAgent(UnitController unit)
    {
        if (!_selectedUnits.Contains(unit))
        {
            Debug.Log(unit.transform.name + " listeye eklendi");
            _selectedUnits.Add(unit);
            unit.IsSelected = true;
        }
        else
        {
            RemoveAgent(unit);
            unit.IsSelected = false;
        }
    }

    public void UnitBoxSelection(Rect selectionBox)
    {
        foreach (var unit in _units)
        {
            if (selectionBox.Contains(Camera.main.WorldToScreenPoint(unit.transform.position)) && !unit.IsSelected)
            {
                AddAgent(unit);
            }
        }
    }

    public void AddUnit(UnitController unit)
    {
        _units.Add(unit);
    }

    public void RemoveAgent(UnitController unit)
    {
        _selectedUnits.Remove(unit);
    }

    public void SetDefault()
    {
        _selectedUnits.ForEach(unit => unit.IsSelected = false);
        _selectedUnits.Clear();
    }

    public void SelectAll()
    {
        _selectedUnits = _units;
        foreach (var unit in _selectedUnits)
        {
            unit.IsSelected = true;
        }
    }
    
    public void ShowCounts()
    {
        int childCount = 0;
        int adultCount = 0;
        int oldCount = 0;

        foreach (var unit in _selectedUnits)
        {
            if (unit.AgentType.Equals("Child"))
            {
                childCount++;
            }
            else if (unit.AgentType.Equals("Adult"))
            {
                adultCount++;
            }
            else
            {
                oldCount++;
            }
        }
        if(_selectedUnits.Count > 0)
           _selectedUnits[0].ShowUnitCountText(childCount, adultCount, oldCount);
    }
}