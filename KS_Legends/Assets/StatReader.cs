using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class StatReader : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerXP playerXP;
    [SerializeField] private Image healthBar, XPBar, manaBar;
    [SerializeField] private TMP_Text levelText;
    
    private void Update()
    {
        healthBar.fillAmount = playerHealth.CurrentHealth / playerHealth.MaxHealth;
        XPBar.fillAmount = playerXP.CurrentXP / playerXP.MaxXP;
        levelText.text = playerXP.CurrentLevel.ToString();
    }
}
