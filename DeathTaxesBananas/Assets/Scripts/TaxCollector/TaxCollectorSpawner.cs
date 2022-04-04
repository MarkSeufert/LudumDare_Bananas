using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxCollectorSpawner : MonoBehaviour
{
    public GameObject _taxCollector;
    public Table _table;
    private List<GameObject> _activeTaxCollectors = new List<GameObject>();

    // Spawn n collectors
    public void SpawnTaxCollectors(int numberToSpawn) 
    {
        _table.ResetTable();
        for (int i = 0; i < numberToSpawn; i++) {
            // Make each one spawn slightly further back then the one before it (so they're not on top of eachother)
            Vector3 spawnPoint = transform.position + transform.forward * i * 2;
            GameObject taxCollectorObject = Instantiate(_taxCollector, spawnPoint, Quaternion.identity) as GameObject;
            TaxCollectorPassive taxCollectorScript = taxCollectorObject.GetComponent<TaxCollectorPassive>();
            _activeTaxCollectors.Add(taxCollectorObject);

            // Configure the variables for this tax collector
            taxCollectorScript._table = _table;
            taxCollectorScript.Activate();
        }
    }

    public void DeleteTaxCollectors() {
        foreach (GameObject taxCollector in _activeTaxCollectors)
            Destroy(taxCollector);
    }
}
