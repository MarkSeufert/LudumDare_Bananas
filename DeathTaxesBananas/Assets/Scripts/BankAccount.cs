using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankAccount : MonoBehaviour
{
    public float _balance = 0f;
    public Text _moneyText;
    public string _preText = "YO TAX BILL: $";

    public void AddBalance(float balance) {
        _balance += balance;
        _moneyText.text = _preText + _balance.ToString();
    }

    // Start is called before the first frame update
    void Restart()
    {
        _balance = 0f;
        _moneyText.text = _preText + "0";
    }
}
