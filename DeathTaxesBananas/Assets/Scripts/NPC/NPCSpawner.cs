using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    // Banana stand variables
    public Table[] _tables;

    // NPC Spawning variables (spawn randomly between the two points)
    public float _spawnRange = 20f;
    public float _spawnRandomness = 5f;

    // NPC variables
    public GameObject _NPC;
    public float _timeBetweenSpawns = 5f;
    public float _sizeVariation = 0f; // The larger, the more variation
    private float _internalTimer = 0f;
    private List<NPC> _activeNPCs = new List<NPC>();

    // Enabling and disabling
    private bool _isEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (!_isEnabled)
            return;

        _internalTimer += Time.deltaTime;
        if (_internalTimer >= _timeBetweenSpawns) {
            _internalTimer = 0;

            // Spawn an NPC
            SpawnNPC();
        }
    }

    void SpawnNPC() {
        GameObject personObject = Instantiate(_NPC) as GameObject;
        NPC person = personObject.GetComponent<NPC>();
        _activeNPCs.Add(person);

        // Pick one of the cashes to walk towards
        int cashIndex = Random.Range(0, _tables.Length);
        person._table = _tables[cashIndex];

        // Spawn them at a random position away from that cash
        Vector2 randomness = Random.insideUnitCircle * _spawnRandomness;
        person.gameObject.transform.position = (_tables[cashIndex].transform.position + _tables[cashIndex].transform.forward * _spawnRange) + new Vector3(randomness.x, 0, randomness.y);

        // Give them a random size and movespeed
        float sizeVariation = Random.Range(_sizeVariation * -1, _sizeVariation);
        personObject.transform.localScale *= 1 + sizeVariation;
        person._bobFreq *= 1 - sizeVariation;

        // Activate the NPC
        person.Activate();
    }

    public void SetSpawning(bool enabled) {
        _isEnabled = enabled;
    }

    public void RunAway() {
        foreach (NPC npc in _activeNPCs) {
            npc.RunAway();
        }
    }

    public void DestroyAll() {
        foreach (NPC npc in _activeNPCs)
        {
            if (npc != null)
                Destroy(npc.gameObject);
        }

        // Reset the tables
        foreach (Table t in _tables)
            t.ResetTable();
    }
}
