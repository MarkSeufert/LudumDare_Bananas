using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TaxCollectorFight : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody _rb;
    public float _moveForce = 5f;
    private bool _enabled = false;
    public float _health = 50;
    public GameObject _deathObject;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetPlayer(GameObject player) {
        _player = player;
        _enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_enabled)
            return; 

        // Apply force towards the player, and make them face the direction
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        _rb.AddForce(direction * _moveForce, ForceMode.Force);
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public void TakeDamage(float amount) {
        _health -= amount;

        // Check if we should die
        if (_health <= 0) {
            Instantiate(_deathObject, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    // Detect if we have touched a player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
        }

    }
}
