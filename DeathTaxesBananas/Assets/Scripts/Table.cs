using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is to contain the information of where the banana stand tables are, the direction it faces, and where to drop the money.
 * It also handles lining up when there are more than one NPC at a desk
 */
public class Table : MonoBehaviour
{
    private Vector3 _tableLocation;
    private Vector3 _tableLineDirection; // The direction that the line will face
    public Transform _moneyDropLocation;
    public Transform _leaveLocation;
    public float _moneyDropRandomness = 0.1f;
    private int _currentlyServingNumber = 0; // The NPC that is currently at the table (not in line)
    private int _maxCustomerNumber = 0; // The current highest customer number
    public float _waitDistance = 1f; // The distance between customers in the line
    // Start is called before the first frame update
    void Start()
    {
        _tableLocation = transform.position;
        _tableLineDirection = transform.forward;
    }

    // Returns the position that a customer with a specific number should move towards
    public Vector3 TargetPosition(int customerNumber) {
        int offset = customerNumber - _currentlyServingNumber;
        return _tableLocation + (_tableLineDirection * _waitDistance * offset);
    }

    // Called when an NPC has been served
    public void BeenServed(int customerNumber) {
        _currentlyServingNumber = customerNumber + 1;
    }

    // Called when an NPC is created and they need to know what customerNumber they are
    public int NewCustomerNumber() {
        _maxCustomerNumber++;
        return _maxCustomerNumber - 1;
    }

    // The location where the customer places their money
    public Vector3 PlaceMoneyLocation() {
        return _moneyDropLocation.position + (Random.insideUnitSphere * _moneyDropRandomness);
    }

    // The location that the customer walks towards after being served
    public Vector3 GetLeaveLocation() {
        return _leaveLocation.position;
    }

    public void ResetTable() {
        _currentlyServingNumber = 0;
        _maxCustomerNumber = 0;
    }
}
