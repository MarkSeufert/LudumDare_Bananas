using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterDuration : MonoBehaviour
{
    public float _timeToDelete = 5f;
    private float _timer = 0f;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeToDelete) {
            Destroy(this.gameObject);
        }
    }
}
