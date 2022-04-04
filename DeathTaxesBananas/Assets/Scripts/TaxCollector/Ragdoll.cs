using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets an initial force to a rigidbody
public class Ragdoll : MonoBehaviour
{
    public Vector3 _deadForce = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(_deadForce);
    }
}
