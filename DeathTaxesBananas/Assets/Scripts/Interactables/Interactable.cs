using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject _highlightObject;
    public bool _isHighlighted = false;
    public string _interactText = "";

    void Start()
    {
        _highlightObject.SetActive(false);
    }

    // Set the highlight to visible
    public void Highlight() {
        _isHighlighted = true;
    }

    // When this object is interacted with
    public abstract void Interact();

    protected void LateUpdate()
    {
        _highlightObject.SetActive(_isHighlighted);

        // Set it back to unhighlighted by default
        _isHighlighted = false;
    }
}
