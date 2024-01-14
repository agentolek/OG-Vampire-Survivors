using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UpgradeManagement : MonoBehaviour
{
    [SerializeField] public List<GameObject> choiceButtons;
    [SerializeField] public GameObject upgradePopup;
    
    private PlayerController _playerController;
    private List<GameObject> _playerAttacks;
    
    // public delegate void Choice1();
    // public delegate void Choice2();
    // public delegate void Choice3();

    private void Start()
    {
        _playerController = GameObject.Find("Player1").GetComponent<PlayerController>();
        _playerAttacks = _playerController.attacks;
        upgradePopup.SetActive(false);
    }

    public void TriggerUpgrade()
    {
        SetUpButtons();
        upgradePopup.SetActive(true);
    }

    private void SetUpButtons()
    {
        foreach (GameObject button in choiceButtons)
        {
            // clears current button, import Button component
            Button currButton =  button.GetComponent<Button>();
            currButton.onClick.RemoveAllListeners();
            
            // connect proper upgrade method to button
            System.Random random = new System.Random();
            GameObject attack = _playerAttacks[random.Next(_playerAttacks.Count)];
            if (attack.GetComponent<AttackBase>().Level < attack.GetComponent<AttackBase>().maxLevel)
            {
                currButton.onClick.AddListener(delegate { UpgradeAttack(attack); });
                ChangeButtonText("level attack", button);
            }
            else
            {
                currButton.onClick.AddListener(delegate
                {
                    int value = random.Next(1, _playerController.PlayerLevel);
                    IncreaseMaxHp(value);
                    ChangeButtonText($"maxHP += {value}", button);
                });
            }
        }
    }
    
    private void ChangeButtonText(string newText, GameObject button)
    {
        button.GetComponentInChildren<Text>().text = newText;
    }
    
    // helper functions, used to pass parameters to methods called by OnClick event.
    private void UpgradeAttack(GameObject attack)
    {
        attack.GetComponent<AttackBase>().Level += 1;
    }

    private void IncreaseMaxHp(int value)
    {
        _playerController.ChangeMaxHp(value);
    }

    public void HideUpgradeScreen()
    {
        upgradePopup.SetActive(false);
    }
    
}
