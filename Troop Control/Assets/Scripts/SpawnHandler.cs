using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : ControllerBase
{
    [SerializeField] private UnitManager _unitManager;
    [SerializeField] private UnitController _child;
    [SerializeField] private UnitController _adult;
    [SerializeField] private UnitController _old;
    [SerializeField] private int _childCount;
    [SerializeField] private int _adultCount;
    [SerializeField] private int _oldCount;
    [SerializeField] private Transform _spawnPoint;
    public override void Initialize()
    {
        Spawn();
    }

    public void Spawn()
    {
        SpawnUnit(_child, _childCount,"Child",2);
        SpawnUnit(_adult, _adultCount,"Adult",1);
        SpawnUnit(_old, _oldCount,"Old",0);
    }

    private void SpawnUnit(UnitController unit, int count, string type, int row)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 position = new Vector3(_spawnPoint.position.x - row, _spawnPoint.position.y, _spawnPoint.position.z + i);
            UnitController unitItem = Instantiate(unit,position , Quaternion.Euler(0,-90,0));
            unitItem.AgentType = type;
            _unitManager.AddUnit(unitItem);
            unitItem.transform.parent = transform;
        }
    }
}