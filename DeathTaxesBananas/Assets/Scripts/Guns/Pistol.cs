using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform _barrelPosition;
    public GameObject _bullet;
    public Rigidbody _player;
    public float _knockback = 10f;

    // Update is called once per frame
    void Update()
    {
        // If we click our mouse and the time between last shot is large enough, shoot a bullet
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
            Instantiate(_bullet, _barrelPosition.position, _barrelPosition.rotation);
            _player.AddForce(transform.forward * -1 * _knockback);
        }
    }
}
