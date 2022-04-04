using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public NPCSpawner _npcSpawner;
    public TaxCollectorSpawner _taxCollectorSpawner;
    public ThemeManager _themeManager;
    public FightManager _fightManager;
    public BankAccount _bankAccount;
    public Transform _bananaStandObjects;
    public Transform _fightObjects;
    public List<GameObject> _livingUI;
    public List<GameObject> _deadUI;
    public Text _scoreText;
    public PlayerMovement _playerMovement;
    public PlayerRotation _playerLooking;

    // Round managing variables
    public float _NPCDuration = 30; // How long NPCs come before a tax collector
    private float _NPCTimeCounter = 0;
    private int _gameState = 0; // 0 is in NPC round, 1 is fighting, 2 is dead
    private int _numTaxCollectors = 1;

    private void Start()
    {
        _gameState = 0;
        _numTaxCollectors = 1;
        foreach (GameObject ui in _livingUI)
        {
            ui.SetActive(true);
        }
        foreach (GameObject ui in _deadUI)
        {
            ui.SetActive(false);
        }

        _playerMovement.enabled = true;
        _playerLooking.enabled = true;
    }

    // Start is called before the first frame update
    void StartNPCRound()
    {
        _gameState = 0;
        _NPCTimeCounter = 0;
        _npcSpawner.SetSpawning(true);
        _themeManager.SetTheme(0);
    }

    void StartTaxCollectorComing() 
    {
        _gameState = 1;
        _npcSpawner.SetSpawning(false);
        _themeManager.SetTheme(2);
        _npcSpawner.RunAway();
        _taxCollectorSpawner.SpawnTaxCollectors(_numTaxCollectors);
    }

    public void LoadFightArea() {
        _npcSpawner.DestroyAll();

        // Disable the banana stand, and spawn the fightable tax collectors
        _bananaStandObjects.gameObject.SetActive(false);
        _fightObjects.gameObject.SetActive(true);
        _taxCollectorSpawner.DeleteTaxCollectors();
        _fightManager.LoadFight(_numTaxCollectors);
    }

    public void EndFight() {
        _bananaStandObjects.gameObject.SetActive(true);
        _fightObjects.gameObject.SetActive(false);
        _numTaxCollectors *= 2;
        StartNPCRound();
    }

    public void GameOver() {
        _gameState = 2;
        _scoreText.text = "Highscore: $" + _bankAccount._balance.ToString();

        foreach (GameObject ui in _livingUI) {
            ui.SetActive(false);
        }
        foreach (GameObject ui in _deadUI)
        {
            ui.SetActive(true);
        }

        _playerMovement.enabled = false;
        _playerLooking.enabled = false;
    }

    void Update()
    {
        if (_gameState == 0) {
            _NPCTimeCounter += Time.deltaTime;

            if (_NPCTimeCounter >= _NPCDuration) {
                StartTaxCollectorComing();
            }
        }

        if (_gameState == 2) {
            if (Input.GetButtonDown("Jump")) {
                SceneManager.LoadScene("Scenes/MainScene");
            }
        }
    }
}
