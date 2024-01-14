using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class GenerateWolves : MonoBehaviour
{

    public GameObject wolf;
    GameObject newWolf;
    public int wolfCount = 50;
    public int numOfWolves;
    public float spawnRadius = 500f;
    public GameObject[] allWolves;

    float waterHeight;

    public GameObject player;


    void Start()
    {
        waterHeight = player.GetComponent<PlayerMovement>().waterHeight;
    }

    void Update()
    {
        numOfWolves = GameObject.FindGameObjectsWithTag("Wolf").Length;
        allWolves = GameObject.FindGameObjectsWithTag("Wolf");

        for (int i = 0; i < allWolves.Length; i++)
        {
            if (allWolves[i].transform.position.y < waterHeight)
            {
                Destroy(allWolves[i]);
            }

            if (allWolves[i].transform.position.y > 20.0f)
            {
                Destroy(allWolves[i]);
            }
        }

    }

    public void WolfDrop()                     //Spawn baddies at random points on Navmesh
    {
        if(wolf.active == true)
        {
            Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
            randomDirection += transform.position;
            NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, spawnRadius, 1);
            Vector3 finalPosition = hit.position;

            newWolf = Instantiate(wolf, hit.position, Quaternion.identity);
            newWolf.tag = "Wolf";
            newWolf.transform.parent = gameObject.transform;
        }
    }


}
