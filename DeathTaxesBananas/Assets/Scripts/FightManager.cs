using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public Transform _playerSpawnPosition;
    public Transform _taxCollectorSpawnPosition;
    public GameObject _TaxCollector;
    public GameObject _player;
    public float _spawnRange = 20;
    private bool _isFighting = false;
    public List<GameObject> taxCollectorList = new List<GameObject>();

    public void LoadFight(int numberTaxCollectors) {
        _player.transform.position = _playerSpawnPosition.position;
        _player.transform.rotation = _playerSpawnPosition.rotation;

        for (int i = 0; i < numberTaxCollectors; i++) {
            float randomSpawnPos = Random.Range(-1 * _spawnRange, _spawnRange);
            GameObject taxCollectorObject = Instantiate(_TaxCollector, _taxCollectorSpawnPosition.position + _taxCollectorSpawnPosition.right * randomSpawnPos, Quaternion.identity);
            TaxCollectorFight taxCollector = taxCollectorObject.GetComponent<TaxCollectorFight>();
            taxCollector.SetPlayer(_player);
            taxCollectorList.Add(taxCollectorObject);
        }

        _isFighting = true;
    }

    // Update is called once per frame
    void Update()
    {
        // If we are fighting, check if all the tax collectors have been killed
        if (_isFighting) {
            bool allDead = true;
            foreach (GameObject taxCollector in taxCollectorList) {
                if (taxCollector != null)
                {
                    allDead = false;
                    break;
                }
            }
            if (allDead) {
                _isFighting = false;

                // If the round is over, wait 2 seconds and end the fight
                StartCoroutine(EndFight());
            }
        }
    }

    IEnumerator EndFight()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().EndFight();
        _player.transform.position = _playerSpawnPosition.position;
        _player.transform.rotation = _playerSpawnPosition.rotation;
    }
}
