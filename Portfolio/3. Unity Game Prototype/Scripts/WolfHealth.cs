using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WolfHealth : MonoBehaviour
{
    public GameObject wolf;
    public GameObject player;
    public Image healthBar;
    public float healthAmount = 100;


    void Update()
    {

        if (healthAmount <= 0 && wolf.GetComponent<WolfController>().isDead == false)
        {
            wolf.GetComponent<WolfController>().Die();
        }


    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;
    }


}
