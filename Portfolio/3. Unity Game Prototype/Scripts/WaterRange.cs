using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRange : MonoBehaviour
{
    public bool isInWaterRange;

    private void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        {
            isInWaterRange = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if(player.tag == "Player")
        {
            isInWaterRange = false;
        }
    }
}
