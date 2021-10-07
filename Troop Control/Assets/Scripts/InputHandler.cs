using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action<Target> OnTargetSelectedOrMoved;
    public event Action<UnitController> OnUnitSelected;
    public event Action<Rect> OnUnitSelectedWithDrag;
    public event Action OnGapSelected;
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private BoxSelectionHandler _boxSelectionHandler;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, 100f, LayerMask.GetMask("Target")))
            {
                Target target = _hit.transform.GetComponent<Target>();
                target.UpdatePosition(_hit.point);
                OnTargetSelectedOrMoved?.Invoke(target);
                Debug.Log("ınvoke");
            }
            else if(Physics.Raycast(_ray, out _hit, 100f, LayerMask.GetMask("Ground")))
            {
                OnGapSelected?.Invoke();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            _boxSelectionHandler.StartPos = Input.mousePosition;
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out _hit, 10000f, LayerMask.GetMask("Unit")))
                {
                    OnUnitSelected?.Invoke(_hit.transform.GetComponentInParent<UnitController>());
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            _boxSelectionHandler.DuringSelection();
        }

        if (Input.GetMouseButtonUp(1))
        {
            OnUnitSelectedWithDrag?.Invoke(_boxSelectionHandler.SelectionBox);
            _boxSelectionHandler.SetDefault();
        }
    
    }

}