using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public GameObject gameManager;
    public TextMeshProUGUI rockText;
    int numberOfUnderwaterRocks;
    public GameObject player;
    public int rockGoal = 10;


    public void Update()
    {
        

        if(numberOfUnderwaterRocks >= rockGoal)
        {
            gameManager.GetComponent<GameManager>().GameWon();
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Rock")
        {
            numberOfUnderwaterRocks++;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Rock")
        {
            numberOfUnderwaterRocks--;
        }
    }
}
