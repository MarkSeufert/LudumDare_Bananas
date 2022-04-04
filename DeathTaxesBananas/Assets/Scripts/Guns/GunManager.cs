using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public List<GameObject> _guns;

    // Use the specified gun
    public void SetGun(int gunNumber) {
        for (int i = 0; i < _guns.Count; i++) {
            _guns[i].SetActive(false);
            if (i == gunNumber)
                _guns[i].SetActive(true);
        }
    }
}
