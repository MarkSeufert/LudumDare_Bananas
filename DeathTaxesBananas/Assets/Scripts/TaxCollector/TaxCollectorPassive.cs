using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the tax collector walking to the table
public class TaxCollectorPassive : Interactable
{
    // Movement variables
    public float _moveSpeed = 5f;
    public float _bobAmount = 0.1f;
    public float _bobFreq = 10f;
    private float _baseYPosition = 0;

    // Table variables
    [HideInInspector] public Table _table;
    private int customerNumber;

    private bool _activated = false;

    // When this TaxCollector becomes active
    public void Activate()
    {
        _activated = true;
        _baseYPosition = transform.position.y;

        // Get our customer number
        customerNumber = _table.NewCustomerNumber();
    }

    // When we interact with them, they teleport us to the kill room
    public override void Interact()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadFightArea();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_activated)
            return;

        Vector3 targetPos = _table.TargetPosition(customerNumber);
        Vector3 velocity = targetPos - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _moveSpeed * Time.deltaTime);

        // Bob up and down, and rotations
        if (Vector3.Distance(transform.position, targetPos) > 0.4f)
        {
            // Move bobbing
            transform.position = new Vector3(transform.position.x,
                                             _baseYPosition + Mathf.Sin(Time.time * _bobFreq) * _bobAmount,
                                             transform.position.z);

            // Face the direction we're moving
            velocity.y = 0;
            transform.rotation = Quaternion.LookRotation(velocity.normalized);
        }
    }

    // If we take damage while walking to the banana stand, nothing happens
    public void TakeDamage(float amount)
    {}
}
