using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class WeatherManager : MonoBehaviour
{

    public float maxTime = 5;
    public float minTime = 2;

    VolumetricClouds volumetricClouds;
    VolumetricClouds.CloudPresets randomCloudy;
    VolumetricClouds.CloudPresets randomClear;
    int randomInt;

    public GameObject sun;
    public GameObject rainPrefab;
    public VolumeProfile volumeProfile;

    public TerrainLayer[] terrainLayers;

    //current time
    float time;
    public bool isRaining;

    //The time to change the rain value
    float rainTime;

    void Start()
    {

        isRaining = false;

        VolumetricClouds vC;
        if (volumeProfile.TryGet<VolumetricClouds>(out vC))
        {
            volumetricClouds = vC;
            randomInt = Random.Range(0, 2);
            if (randomInt == 0)
            {
                randomClear = VolumetricClouds.CloudPresets.Sparse;
            }
            else
            {
                randomClear = VolumetricClouds.CloudPresets.Cloudy;
            }

            volumetricClouds.cloudPreset.value = randomClear;
        }

        SetRandomTime();
        time = 1f;

        for (int i = 0; i < terrainLayers.Length; i++)
        {
            TerrainLayer terrainLayer = terrainLayers[i];
            terrainLayer.smoothness = 0f;
        }

    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to change rain value
        if (time >= rainTime)
        {
            Rain();
            SetRandomTime();
        }

        //Debug.Log("isRaining: " + isRaining + "\ntime: " + time + "\nrainTime: " + rainTime);

    }


    //Changes rain value and resets the time
    void Rain()
    {
        time = minTime;
        if (isRaining == true)
        {
            randomInt = Random.Range(0, 2);
            if(randomInt == 0)
            {
                randomCloudy = VolumetricClouds.CloudPresets.Overcast;
            }
            else
            {
                randomCloudy = VolumetricClouds.CloudPresets.Stormy;
            }

            volumetricClouds.cloudPreset.value = randomCloudy;
            sun.GetComponent<LensFlareComponentSRP>().enabled = false;

            for (int i = 0; i < terrainLayers.Length; i++)
            {
                TerrainLayer terrainLayer = terrainLayers[i];
                terrainLayer.smoothness = 0.75f;
            }

        }

        if (isRaining == false)
        {
            randomInt = Random.Range(0, 2);
            if (randomInt == 0)
            {
                randomClear = VolumetricClouds.CloudPresets.Sparse;
            }
            else
            {
                randomClear = VolumetricClouds.CloudPresets.Cloudy;
            }

            volumetricClouds.cloudPreset.value = randomClear;
            sun.GetComponent<LensFlareComponentSRP>().enabled = true;

            for (int i = 0; i < terrainLayers.Length; i++)
            {
                TerrainLayer terrainLayer = terrainLayers[i];
                terrainLayer.smoothness = 0f;
            }

        }
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        rainTime = Random.Range(minTime, maxTime);

        if (isRaining == true)
        {
            isRaining = false;
        }
        else
        {
            isRaining = true;
        }

        time = 1f;
    }

}
