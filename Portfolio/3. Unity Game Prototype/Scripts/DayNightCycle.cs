using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class DayNightCycle : MonoBehaviour
{

    public GameObject fireFlies;
    public GameObject sun;

    public VolumeProfile volumeProfile;
    public Volume volume;

    VolumetricClouds volumetricClouds;
    PhysicallyBasedSky physicallyBasedSky;

    public GameObject wolfSpawner;
    GenerateWolves generateWolves;

    public AudioSource dayAmbience;
    public AudioSource nightAmbience;


    public float currentTime;
    public float dayLengthMinutes;

    public TextMeshProUGUI timeText;

    float rotationSpeed;
    float midDay;
    float translateTime;
    string AMPM = "AM";

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 360 / dayLengthMinutes / 60;
        midDay = dayLengthMinutes * 60 / 2;
        generateWolves = wolfSpawner.GetComponent<GenerateWolves>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;

        transform.Rotate(new Vector3(1, 0, 0) * rotationSpeed * Time.deltaTime);

        translateTime = (currentTime / (midDay * 2));

        float t = translateTime * 24f;

        float hours = Mathf.Floor(t);

        string displayHours = hours.ToString();
        if(hours == 0)
        {
            displayHours = "12";
        }

        if(hours > 12)
        {
            displayHours = (hours - 12).ToString();
        }

        if(currentTime >= midDay)
        {
            if(AMPM != "PM")
            {
                AMPM = "PM";
            }
        }

        if(currentTime >= midDay * 2)
        {
            if(AMPM != "AM")
            {
                AMPM = "AM";
            }
            currentTime = 0;
        }

        t *= 60;
        float minutes = Mathf.Floor(t % 60);

        string displayMinutes = minutes.ToString();
        if(minutes < 10)
        {
            displayMinutes = "0" + minutes.ToString();
        }

        string displayTime = displayHours + ":" + displayMinutes + " " + AMPM;

        timeText.text = displayTime;

        if(hours >= 5 && hours <=19)
        {
            fireFlies.SetActive(false);
            dayAmbience.enabled = true;
            nightAmbience.enabled = false;
        }
        else
        {
            fireFlies.SetActive(true);
            dayAmbience.enabled = false;
            nightAmbience.enabled = true;
        }

        if (fireFlies.activeInHierarchy == true && generateWolves.numOfWolves < generateWolves.wolfCount)
        {
            generateWolves.WolfDrop();
        }

        VolumetricClouds vC;
        if (volumeProfile.TryGet<VolumetricClouds>(out vC))
        {
            volumetricClouds = vC;
            volumetricClouds.shadows.overrideState = true;
        }

        if ((hours >= 5 && hours <= 7) || (hours >= 17 && hours <= 19))
        {
            volumetricClouds.shadows.Override(false);
        }
        else
        {
            volumetricClouds.shadows.Override(true);
        }

        if (volume.sharedProfile.TryGet(out physicallyBasedSky))
        {
            Vector3 current = physicallyBasedSky.spaceRotation.value;
            float sunX = sun.transform.eulerAngles.x;
            current.x += Time.deltaTime * (rotationSpeed / 2);
            current.z += Time.deltaTime * (rotationSpeed / 6);
            physicallyBasedSky.spaceRotation.value = current;
        }
    }
}
