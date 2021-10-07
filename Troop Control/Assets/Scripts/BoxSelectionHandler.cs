using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxSelectionHandler : MonoBehaviour
{
    private InputHandler _inputHandler; 
    [SerializeField] private RectTransform _boxVisual;
    private Rect _selectionBox;
    private Vector2 _startPos;
    private Vector2 _endPos;
    public Rect SelectionBox => _selectionBox;
    public Vector2 StartPos
    {
        get => _startPos;
        set
        {
            _startPos = value;
        }
    } 
    public Vector2 EndPos
    {
        get { return _endPos; }
        set { _endPos = value; }
    }

    public void DuringSelection()
    {
        EndPos = Input.mousePosition;
        DrawSelectionBox();
        DrawSelection();
    }
    private void DrawSelectionBox()
    {
        Vector2 boxStart = _startPos;
        Vector2 boxEnd = _endPos;
      
        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        
        _boxVisual.position = boxCenter;
        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
        
        _boxVisual.sizeDelta = boxSize;
    }

    private void DrawSelection()
    {
        if (Input.mousePosition.x < _startPos.x)
        {
            _selectionBox.xMin = Input.mousePosition.x;
            _selectionBox.xMax = _startPos.x;
        }
        else
        {
            _selectionBox.xMin = _startPos.x;
            _selectionBox.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < _startPos.y)
        {
            _selectionBox.yMin = Input.mousePosition.y;
            _selectionBox.yMax = _startPos.y;
        }
        else
        {
            _selectionBox.yMin = _startPos.y;
            _selectionBox.yMax = Input.mousePosition.y;
        }
    }

    public void SetDefault()
    {
        StartPos = Vector2.zero;
        EndPos = Vector2.zero;
        _boxVisual.sizeDelta = Vector2.zero;

    }
}
