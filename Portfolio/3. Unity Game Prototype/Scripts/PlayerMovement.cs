using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 7.5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float hitDistance = 3;
    public float hitRate = 1.5f;
    public float hitDmg = 25;
    float nextHit;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float waterHeight = 11.8f;
    public bool isUnderwater;
    public float waterJumpHeight = 1.0f;
    public bool isUnderwaterJump;
    public float underwaterSpeed = 5f;
    public VolumeProfile volumeProfile;

    public int healAmount = 25;

    public GameObject bubbles;

    public GameObject meatObj;

    bool isInWaterRange;
    public GameObject waterRangeObj;

    public GameObject sun;

    Bloom bloom;
    Fog fog;
    ColorAdjustments colorAdjustments;

    bool isSprinting = false;
    bool isCrouching = false;

    CharacterController characterCollider;

    public GameObject gameManager;
    public GameObject wolfController;
    public bool isTakingDamage;

    float randomInt;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController>();

        if (volumeProfile.TryGet<Bloom>(out Bloom b))
        {
            bloom = b;
            bloom.active = false;
        }

        if (volumeProfile.TryGet<Fog>(out Fog f))
        {
            fog = f;
            fog.meanFreePath.value = 636f;
            fog.tint.overrideState = false;
        }

        if (volumeProfile.TryGet<ColorAdjustments>(out ColorAdjustments cA))
        {
            colorAdjustments = cA;
            colorAdjustments.active = false;
        }

        sun.GetComponent<Light>().colorTemperature = 5463f;
        sun.GetComponent<HDAdditionalLightData>().intensity = 30908.9f;

        bubbles.SetActive(false);

    }


    void Update()               //Allows the player to use keyboard input to move and jump
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        isInWaterRange = waterRangeObj.GetComponent<WaterRange>().isInWaterRange;

        if (isGrounded && velocity.y < 0 && isUnderwater == false)
        {
            velocity.y = -2f;
        }

        if(gameObject.transform.position.y < waterHeight && isInWaterRange == true)
        {
            isUnderwater = true;
        }
        else
        {
            isUnderwater = false;
        }

        if(gameObject.transform.position.y < waterHeight + waterJumpHeight && isInWaterRange == true)
        {
            isUnderwaterJump = true;
        }
        else
        {
            isUnderwaterJump = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && isUnderwater == false)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }    

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(isUnderwater == false)
        {

            bloom.active = false;
            fog.meanFreePath.value = 636f;
            fog.maxFogDistance.value = 100f;
            fog.tint.overrideState = false;
            colorAdjustments.active = false;

            bubbles.SetActive(false);

            sun.GetComponent<Light>().colorTemperature = 5463f;
            sun.GetComponent<HDAdditionalLightData>().intensity = 30908.9f;

            if (Input.GetKey(KeyCode.LeftShift).Equals(true) && isCrouching == false)
            {
                isSprinting = true;
                speed = 15f;
            }
            else if (isCrouching == false)
            {
                isSprinting = false;
                speed = 7.5f;
            }

            if (Input.GetKey(KeyCode.LeftControl).Equals(true) && isSprinting == false)
            {
                isCrouching = true;
                characterCollider.height = 1.9f;
                speed = 4f;
            }
            else if (isSprinting == false)
            {
                isCrouching = false;
                characterCollider.height = 3.8f;
                speed = 7.5f;
            }

            gravity = -9.81f;
        }

        if(isUnderwater == true)
        {
            bloom.active = true;
            fog.meanFreePath.value = 25f;
            fog.maxFogDistance.value = 10f;
            fog.tint.overrideState = true;
            colorAdjustments.active = true;

            bubbles.SetActive(true);

            sun.GetComponent<Light>().colorTemperature = 17160f;
            sun.GetComponent<HDAdditionalLightData>().intensity = 3000f;

            if (Input.GetKey(KeyCode.LeftShift).Equals(true) && isCrouching == false)
            {
                isSprinting = true;
                speed = 7.5f;
            }
            else if (isCrouching == false)
            {
                isSprinting = false;
                speed = 3.75f;
            }

            if (Input.GetKey(KeyCode.LeftControl).Equals(true) && isSprinting == false)
            {
                isCrouching = true;
                characterCollider.height = 1.9f;
                speed = 2f;
            }
            else if (isSprinting == false)
            {
                isCrouching = false;
                characterCollider.height = 3.8f;
                speed = 4f;
            }

            gravity = -2.0f;

        }

        if (Input.GetButton("Jump") && isUnderwaterJump == true)
        {
            velocity.y = Mathf.Sqrt((jumpHeight / 2) * -2f * gravity);
        }

        if(Input.GetMouseButtonDown(0).Equals(true))
        {
            Hit();
        }

    }

    void Hit()
    {

        if (Time.time > nextHit)
        {
            nextHit = Time.time + hitRate;

            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, hitDistance))
            {
                if (hit.transform.tag == "Wolf" && isTakingDamage == false && wolfController.GetComponent<WolfController>().isDead == false)
                {
                    isTakingDamage = true;
                    wolfController.GetComponent<Animator>().Play("damage");
                    randomInt = Random.Range(0, 3);
                    gameManager.GetComponent<WolfHealth>().TakeDamage(hitDmg);
                    Debug.Log("Damaging");
                    isTakingDamage = false;
                }
            }

        }


        void OnApplicationQuit()
        {
            bloom.active = false;
            fog.meanFreePath.value = 636f;
            fog.tint.overrideState = false;
            colorAdjustments.active = false;
        }

    }
}

