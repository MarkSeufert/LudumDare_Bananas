using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : Interactable
{
    public float _moneyAmount = 100;
    public GameObject _moneyDestroyEffect;
    public override void Interact() {
        // Find the bankaccount, and add a balance to it
        GameObject.FindGameObjectWithTag("BankAccount").GetComponent<BankAccount>().AddBalance(_moneyAmount);
        Instantiate(_moneyDestroyEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
