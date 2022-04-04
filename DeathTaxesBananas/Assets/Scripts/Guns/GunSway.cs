using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour
{
    public float _swayAmount = 30f;
    public float _smoothness = 5f;

    // Update is called once per frame
    void Update()
    {
        Quaternion xRotation = Quaternion.AngleAxis(Input.GetAxisRaw("Mouse Y") * _swayAmount, Vector3.right);
        Quaternion yRotation = Quaternion.AngleAxis(Input.GetAxisRaw("Mouse X") * _swayAmount * 0.5f, Vector3.up);
        if (Input.GetMouseButtonDown(0))
        {
            xRotation = Quaternion.AngleAxis(200 * _swayAmount, Vector3.right);
        }

        transform.localRotation = Quaternion.Slerp(transform.localRotation, xRotation * yRotation, _smoothness * Time.deltaTime);
    }
}
