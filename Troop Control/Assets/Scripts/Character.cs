using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject selectionItem;
    [SerializeField] private TextMeshPro _text;
    
    
    public void PlayAnimation(string name)
    {
        _animator.Play(name,-1,-1);
    }
    public void SelectionQuadShow()
    {
        selectionItem.SetActive(true);
    }

    public void SelectionQuadHide()
    {
        selectionItem.SetActive(false);
    }

    public void ShowText(int childCount, int adultCount, int oldCount)
    {
        _text.enabled = true;
        _text.text = "Child x" + childCount + " Adult x" + adultCount + " Old x" + oldCount;
    }

    public void HideText()
    {
        _text.enabled = false;
        _text.text = "";
    }
}