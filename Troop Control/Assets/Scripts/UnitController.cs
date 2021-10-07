using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField] private Character _unitVisual;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    private int currentSpeed = 3;
    private string _agentType;
    private float _targetDistance;
    private Transform _targetTransform;
    private bool isSelected;
    private bool isMoving;
    public void Initialize()
    {
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updatePosition = true;
    }

    public string AgentType
    {
        get => _agentType;
        set { _agentType = value; }
    }

    public Transform TargetTransform
    {
        get => _targetTransform;
        set { _targetTransform = value; }
    }

    public float TargetDistance
    {
        get => _targetDistance;
        set
        {
            _targetDistance = value;
        }
    }

    public bool IsSelected
    {
        get => isSelected;
        set { isSelected = value; }
    }

    public void SetSpeed(int speed)
    {
        _navMeshAgent.speed = speed;
        currentSpeed = speed;
    }

    private void CheckTargetDistance()
    {
        float distance = Vector3.Distance(transform.position, _targetTransform.position);
        if (distance <= TargetDistance)
            
            _navMeshAgent.speed = Mathf.FloorToInt(_navMeshAgent.speed * .25f);
        
        if (distance <= _navMeshAgent.stoppingDistance)
        {
            _unitVisual.PlayAnimation("Breathing Idle");
            SetDefault();
        }
    }

    private void Update()
    {
        if (_targetTransform != null)
        {
            _navMeshAgent.SetDestination(_targetTransform.position);
            if (!isMoving)
            {
                Movement();
                isMoving = true;
            }
            CheckTargetDistance();
        }
        else
        {
            SetDefault();
        }

        SelectionItemUpdate();
    }

    public void SelectionItemUpdate()
    {
        if (isSelected)
            _unitVisual.SelectionQuadShow();
        else
            _unitVisual.SelectionQuadHide();
    }

    public void SetDefault()
    {
        isMoving = false;
        _unitVisual.HideText();
        _navMeshAgent.speed = currentSpeed;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        SetSpeed(0);
        if (LayerMask.GetMask("Unit") == other.gameObject.layer)
        {
            other.GetComponent<UnitController>().SetSpeed(0);
            other.transform.position += Vector3.right;
        }
    }

    public void ShowUnitCountText(int child, int adult, int old)
    {
        _unitVisual.ShowText(child,adult,old);
    }

    private void Movement()
    {
        if (_navMeshAgent.speed >= 5)
        {
            _unitVisual.PlayAnimation("Running");
        }
        else
        {
            _unitVisual.PlayAnimation("Walking");
        }
            
    }
}