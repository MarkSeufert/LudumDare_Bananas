using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUnlock : Interactable
{
    public BankAccount bankAccount;
    public float _amountToUnlock = 10f;
    public GunManager _gunManager;
    public int _gunIndex = 0;

    override public void Interact() 
    {
        if (bankAccount._balance >= _amountToUnlock) {
            bankAccount.AddBalance(-1 * _amountToUnlock);
            _gunManager.SetGun(_gunIndex);
            Destroy(this.gameObject);
        }
    }
}
