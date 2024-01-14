using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RockCounter : MonoBehaviour
{
    public GameObject gameManager;
    public TextMeshProUGUI time;
    int numberOfUnderwaterRocks;
    public GameObject player;
    int timeLeft;


    public void Update()
    {
        timeLeft = (int)(20 - Time.time);
        time.text = "Survive for: " + timeLeft;


        if(Time.time >= 20)
        {
            gameManager.GetComponent<GameManager>().GameWon();
        }
    }


}
