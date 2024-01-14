using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject gameManager;
    public Image healthBar;
    public float healthAmount = 100;
    public TextMeshProUGUI healthNumber;
    bool healOverTime;


    void Update()
    {
        if(healthAmount <= 0)
        {
            gameManager.GetComponent<GameManager>().EndGame();
        }

    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;
        string displayHealth = healthAmount.ToString();
        healthNumber.text = displayHealth;
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;
        string displayHealth = healthAmount.ToString();
        healthNumber.text = displayHealth;
    }



}
