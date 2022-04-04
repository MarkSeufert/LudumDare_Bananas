using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Don't destroy so that it keeps playing even after switching scenes
        DontDestroyOnLoad(gameObject);
    }
}
