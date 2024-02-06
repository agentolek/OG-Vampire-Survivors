using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // --- public variables

    [SerializeField] public int hp = 10;
    [SerializeField] public int maxHp = 10;

    [SerializeField] public int xp = 0;
    [SerializeField] public int maxXp = 10;

    [SerializeField] public List<GameObject> attacks;

    public int PlayerLevel { get; set; } = 1;

    // --- private variables

    private SpriteRenderer _sprite;
    private UIManagement _uiManager;
    private GameManagement _gameManager;
    private UpgradeManagement _upgradeController;

    // --- private methods
    void Start()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManagement>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagement>();
        _upgradeController = GameObject.Find("UpgradeManager").GetComponent<UpgradeManagement>();
        _uiManager.UpdateXp(xp, maxXp);
        SetupAttacks();
    }

    IEnumerator ChangeColor(Color color)
    {

        _sprite.color = color;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.white;

    }

    private void ChangeHp(int value)
    {
        hp = hp + value;
        _uiManager.UpdateHp(hp, maxHp);
        if (hp <= 0)
        {
            Die();
        }
    }

    private void LevelUp()
    {
        // changes player stats
        PlayerLevel += 1;
        xp -= maxXp;
        maxXp = Mathf.RoundToInt(maxXp * 1.2f);

        _upgradeController.TriggerUpgrade();
    }


    public void SetupAttacks()
    {
        // if attack's level is 0, hide it, otherwise show it
        foreach (var attack in attacks)
        {
            Debug.Log(attack.name + " " + attack.GetComponent<AttackBase>().Level);
            attack.SetActive(attack.GetComponent<AttackBase>().Level != 0);
        }
    }


    private void Die()
    {
        gameObject.SetActive(false);
        GameManagement.GameFinished = false;
        _gameManager.FinishGame();
    }

    // --- public methods
    public void TakeDamage(int damage, GameObject toBeKnocked = null)
    {
        ChangeHp(-1 * damage);

        StartCoroutine(ChangeColor(Color.red));
    }


    public void AddXp(int value)
    {
        xp += value;
        if (xp >= maxXp)
        {
            LevelUp();
            AddXp(0);
        }

        _uiManager.UpdateXp(xp, maxXp);
    }

    public void ChangeMaxHp(int value)
    {
        maxHp += value;
        ChangeHp(value);
    }
}
