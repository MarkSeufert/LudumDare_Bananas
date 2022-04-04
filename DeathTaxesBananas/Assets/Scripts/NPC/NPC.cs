using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    // Movement variables
    public float _moveSpeed = 5f;
    public float _bobAmount = 0.1f;
    public float _bobFreq = 10f;
    private float _baseYPosition = 0;

    // Table variables
    [HideInInspector] public Table _table;
    private int customerNumber;
    private bool _hasBeenServed = false;

    // Other variables
    public GameObject _moneyToDrop;
    public Vector3 _leaveLocation;
    private bool _activated = false;

    // When this NPC becomes active
    public void Activate() {
        _leaveLocation = _table.GetLeaveLocation();
        _activated = true;

        // Get our customer number
        customerNumber = _table.NewCustomerNumber();

        _baseYPosition = transform.position.y;
    }

    // When we interact with them, they drop money on the table and they walk away
    public override void Interact()
    {
        _hasBeenServed = true;
        Instantiate(_moneyToDrop, _table.PlaceMoneyLocation(), Quaternion.identity);
        _table.BeenServed(customerNumber);
    }

    // Causes this NPC to run away in fear
    public void RunAway() {
        _hasBeenServed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_activated)
            return;

        Vector3 targetPos = _table.TargetPosition(customerNumber);
        Vector3 velocity = targetPos - transform.position;
        if (!_hasBeenServed)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, _moveSpeed * Time.deltaTime);
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, _leaveLocation, _moveSpeed * Time.deltaTime);

            // Delete this NPC if they've arrived at their end position
            if (Vector3.Distance(transform.position, _leaveLocation) < 1f)
                Destroy(this.gameObject);
        }

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
}
