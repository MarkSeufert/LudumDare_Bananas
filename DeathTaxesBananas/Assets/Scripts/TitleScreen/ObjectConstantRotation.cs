using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectConstantRotation : MonoBehaviour
{
    public Vector3 _rotationSpeed = Vector3.zero; // Rotation amount per second

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        transform.rotation = transform.rotation * Quaternion.Euler(_rotationSpeed * Time.deltaTime);
    }
}
