using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float _damage = 5f;
    public float _speed = 20f;
    public float _knockbackForce = 5f;
    public float _gravity = 2f;
    public GameObject _explodeEffect;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(_speed * transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If our bullet hit a tax collector, reduce it's health and knock it back slightly
        if (collision.gameObject.tag == "TaxCollector")
        {
            // Take damage
            TaxCollectorFight taxCollectorScript = collision.gameObject.GetComponent<TaxCollectorFight>();
            if (taxCollectorScript == null) {
                TaxCollectorPassive taxCollectorPassiveScript = collision.gameObject.GetComponent<TaxCollectorPassive>();
                taxCollectorPassiveScript.TakeDamage(_damage);

                return;
            }
            taxCollectorScript.TakeDamage(_damage);

            // Push back
            Vector3 bulletDirection = GetComponent<Rigidbody>().velocity.normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(bulletDirection * _knockbackForce, ForceMode.Force);
        }

        // Destroy this bullet
        Instantiate(_explodeEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        // Apply gravity
        GetComponent<Rigidbody>().AddForce(_gravity * Vector3.down);
    }
}
