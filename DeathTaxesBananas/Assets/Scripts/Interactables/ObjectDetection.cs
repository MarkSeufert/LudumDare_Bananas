using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDetection : MonoBehaviour
{
    private Interactable _selectedObject = null;
    public LayerMask _interactableLayer;
    public float _selectRange = 0.5f;
    public Text _selectionText;

    // Update is called once per frame
    void Update()
    {
        // Detect any interactable objects within range
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _selectRange, _interactableLayer))
        {
            _selectedObject = hit.transform.GetComponent<Interactable>();

            // Highlight this object, and activate it if clicked
            _selectedObject.Highlight();
            if (Input.GetKeyDown(KeyCode.E))
            {
                _selectedObject.Interact();
            }

            // Change the selection text
            _selectionText.text = _selectedObject._interactText;
        }
        else
        {
            _selectionText.text = "";
        }
    }
}
