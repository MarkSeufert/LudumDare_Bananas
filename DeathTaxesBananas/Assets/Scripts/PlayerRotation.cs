using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * This script is used to rotate the player/camera using the mouse.
 */ 
public class PlayerRotation : MonoBehaviour
{
    public GameObject _camera;
    public float _mouseSensitivity = 10f;
    public float _YRotationClamp = 70;
    private Vector2 _targetRotation = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _targetRotation += new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * _mouseSensitivity;
        _targetRotation.y = Mathf.Clamp(_targetRotation.y, -1 * _YRotationClamp, _YRotationClamp);
        transform.rotation = Quaternion.Euler(new Vector3(0, _targetRotation.x, 0));
        _camera.transform.localRotation = Quaternion.Euler(new Vector3(_targetRotation.y * -1, 0, 0));
    }
}
