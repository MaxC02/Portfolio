using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfController : MonoBehaviour
{

    public float lookRadius = 20f;

    public Transform target;
    public NavMeshAgent agent;

    public GameObject wolfObj;

    Animator wolfAnimator;

    public LayerMask playerMask;
    public LayerMask groundMask;

    string randomAttack;
    AudioSource randomAttackSound;
    int randomInt;

    public Transform holdAreaWolf;

    AudioSource randomHowlSound;
    bool isHowling;

    AudioSource randomDeathSound;
    public bool isDead = false;

    AudioSource randomHurtSound;

    AudioSource audioSource;

    public AudioSource wolfAttack1;
    public AudioSource wolfAttack2;
    public AudioSource wolfChase;
    public AudioSource wolfDeath1;
    public AudioSource wolfDeath2;
    public AudioSource wolfFlee;
    public AudioSource wolfHowl1;
    public AudioSource wolfHowl2;
    public AudioSource wolfHowl3;
    public AudioSource wolfHowl4;
    public AudioSource wolfHurt1;
    public AudioSource wolfHurt2;
    public AudioSource wolfHurt3;

    public int killCount = 0;

    float wanderTime;
    public float sitTime;
    public float delayInterval;
    bool isSitting;
    float howlAnimationTime;

    float waterHeight;

    public GameObject gameManager;

    public float attackDmg = 10;

    public GameObject meat;

    //Patrolling
    public Vector3 waypoint;
    [SerializeField] bool waypointSet;
    public float waypointRange;

    //Attacking
    public float timeBetweenAttacks;
    [SerializeField] bool alreadyAttacked;
    [SerializeField] bool isAttacking;
    [SerializeField] bool isAttackAnimationPlaying;
    [SerializeField] bool isSitAnimationPlaying;

    //States
    public float sightRange;
    public float attackRange;

    [SerializeField] bool playerInLookRadius;
    [SerializeField] bool playerInAttackRange;
    [SerializeField] bool isChasingPlayer;

    public int wolvesDead;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();          //Assigns wolf to the NavmeshAgent

        wolfAnimator = gameObject.GetComponent<Animator>();

        isAttacking = false;
        isAttackAnimationPlaying = false;

        audioSource = GetComponent<AudioSource>();
        wolfAnimator.StartPlayback();
        wolfAnimator.speed = 1f;
    }


    private void Update()
    {

        //Check for sight and attack range
        playerInLookRadius = Physics.CheckSphere(transform.position, lookRadius, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        //If player is not within sight or attack range then wolf will wander around
        if (!playerInLookRadius && !playerInAttackRange && gameManager.GetComponent<Health>().healthAmount != 0 && isDead == false && target.GetComponent<PlayerMovement>().isTakingDamage == false)
        {
            Wander();
            agent.speed = 4.0f;

        }

        //If player is within sight range but not attack range of the player then wolf will chase player
        if (playerInLookRadius && !playerInAttackRange && gameManager.GetComponent<Health>().healthAmount != 0 && isDead == false && target.GetComponent<PlayerMovement>().isTakingDamage == false)
        {
            ChasePlayer();
            agent.speed = 12f;
            isChasingPlayer = true;
        }
        else
        {
            isChasingPlayer = false;
        }

        //If player is both within sight and attack range the wolf will attack player
        if (playerInAttackRange && playerInLookRadius && isAttacking == false && gameManager.GetComponent<Health>().healthAmount != 0 && isDead == false && target.GetComponent<PlayerMovement>().isTakingDamage == false)
        {
            randomInt = Random.Range(0, 2);
            if (randomInt == 0 && isDead == false)
            {
                randomAttack = "attack1";
                randomAttackSound = wolfAttack2;
            }
            
            if (randomInt == 1 && isDead == false)
            {
                randomAttack = "attack2";
                randomAttackSound = wolfAttack1;
            }

            if(isDead == false)
            {
                agent.speed = 0f;
                AttackPlayer();

                randomAttackSound.Play();
                wolfAnimator.Play(randomAttack);
                isAttackAnimationPlaying = true;
            }
            
        }

        if (gameManager.GetComponent<Health>().healthAmount == 0 && playerInAttackRange && playerInLookRadius && isDead == false && target.GetComponent<PlayerMovement>().isTakingDamage == false)
        {
            wolfAnimator.Play("eating");
        }

        if (agent.velocity.magnitude < 6.0f && agent.velocity.magnitude > 0.5f && isDead == false && target.GetComponent<PlayerMovement>().isTakingDamage == false)
        {
            wolfAnimator.Play("walk");
            isAttackAnimationPlaying = false;
            isAttacking = false;
        }

        if (agent.velocity.magnitude < 13.0f && agent.velocity.magnitude > 6.0f && isDead == false && target.GetComponent<PlayerMovement>().isTakingDamage == false)
        {
            wolfAnimator.Play("run");
            isAttackAnimationPlaying = false;
            isAttacking = false;
        }

        if (agent.velocity.magnitude == 0f && isAttacking == false && gameManager.GetComponent<Health>().healthAmount != 0 && isSitting == false && isDead == false && target.GetComponent<PlayerMovement>().isTakingDamage == false)
        {
            wolfAnimator.Play("breathes");
            isAttackAnimationPlaying = false;
            isAttacking = false;
        }

        if(isSitting && isDead == false && target.GetComponent<PlayerMovement>().isTakingDamage == false)
        {
            wolfAnimator.SetBool("IsSitting", true);
        }
        else
        {
            wolfAnimator.SetBool("IsSitting", false);
        }

        if(target.GetComponent<PlayerMovement>().isTakingDamage == true)
        {
            randomInt = Random.Range(0, 3);
            if (randomInt == 0)
            {
                randomHurtSound = wolfHurt1;
            }

            if (randomInt == 1)
            {
                randomHurtSound = wolfHurt2;
            }

            if (randomInt == 2)
            {
                randomHurtSound = wolfHurt3;
            }

            randomHurtSound.Play();

        }

    }

    void Wander()               //Checks if there is a waypoint existing and if so sets it has the destination for the wolf AI
    {

        if (!waypointSet)
        {
            randomInt = Random.Range(0, 100);
            if (randomInt <= 25 && isHowling == false)
            {
                randomInt = Random.Range(0, 5);
                if (randomInt == 0)
                {
                    agent.speed = 0f;
                    wolfAnimator.SetFloat("HowlLength", 1f);
                    wolfAnimator.Play("howl");
                    wolfHowl1.Play();
                    AnimatorStateInfo info = wolfAnimator.GetCurrentAnimatorStateInfo(0);
                    howlAnimationTime = info.length;
                    Invoke(nameof(SearchWaypoint), howlAnimationTime + 0.5f);
                    isHowling = true;
                }

                if (randomInt == 1)
                {
                    agent.speed = 0f;
                    wolfAnimator.SetFloat("HowlLength", 0.75f);
                    wolfAnimator.Play("howl");
                    wolfHowl2.Play();
                    AnimatorStateInfo info = wolfAnimator.GetCurrentAnimatorStateInfo(0);
                    howlAnimationTime = info.length;
                    Invoke(nameof(SearchWaypoint), howlAnimationTime + 0.5f);
                    isHowling = true;
                }

                if (randomInt == 2)
                {
                    agent.speed = 0f;
                    wolfAnimator.SetFloat("HowlLength", 0.75f);
                    wolfAnimator.Play("howl");
                    wolfHowl3.Play();
                    AnimatorStateInfo info = wolfAnimator.GetCurrentAnimatorStateInfo(0);
                    howlAnimationTime = info.length;
                    Invoke(nameof(SearchWaypoint), howlAnimationTime + 0.5f);
                    isHowling = true;
                }

                if (randomInt == 3)
                {
                    agent.speed = 0f;
                    wolfAnimator.SetFloat("HowlLength", 1f);
                    wolfAnimator.Play("howl");
                    wolfHowl4.Play();
                    AnimatorStateInfo info = wolfAnimator.GetCurrentAnimatorStateInfo(0);
                    howlAnimationTime = info.length;
                    Invoke(nameof(SearchWaypoint), howlAnimationTime + 0.5f);
                    isHowling = true;
                }
                else
                {
                    SearchWaypoint();
                    wanderTime = Time.time;
                    isHowling = false;
                }
            }
        }

        if (waypointSet)
        {
            agent.SetDestination(waypoint);
            isHowling = false;
        }
            

            Vector3 distanceToWaypoint = transform.position - waypoint;

        //Waypoint reached
        if (distanceToWaypoint.magnitude < 5.0f)
        {
            waypointSet = false;
        }

        if (Time.time - wanderTime >= sitTime && agent.velocity.magnitude >= 0f && agent.velocity.magnitude <= 0.75f)
        {
            wolfAnimator.Play("sitting");
            isSitting = true;

        }
        else
        {
            isSitting = false;
        }

        if (Time.time - wanderTime >= delayInterval)
        {
            waypointSet = false;
        }


    }

    void SearchWaypoint()               //Sets a new random waypoint on the NavMesh within a range of the wolf
    {
        float randomZ = Random.Range(-waypointRange, waypointRange);
        float randomX = Random.Range(-waypointRange, waypointRange);

        waypoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(waypoint, -transform.up, 5f, groundMask))
        {
            waypointSet = true;
        }


    }

    void ChasePlayer()                  //Sets the player as the destination for the NavMeshAgent so that the wolf will chase them
    {
        agent.SetDestination(target.position);
        if(isChasingPlayer == false && isDead == false)
        {
            wolfChase.Play();
        }
    }

    void AttackPlayer()                 //Makes the wolf look at the player and perform a series of attacks at intervals
    {
        isAttacking = true;
        AnimatorStateInfo info = wolfAnimator.GetCurrentAnimatorStateInfo(0);
        if(isAttackAnimationPlaying == true)
        {
            timeBetweenAttacks = info.length;
        }

        //Stop baddy when attacking
        agent.SetDestination(transform.position);

        if (!alreadyAttacked)
        {
            gameManager.GetComponent<Health>().TakeDamage(attackDmg);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    void ResetAttack()                  //Resets the time between attack
    {
        alreadyAttacked = false;
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(waypoint, 5.0f);
    }
    

    public void DamageWolf()
    {
        gameObject.GetComponent<WolfHealth>().TakeDamage(20f);
    }

    public void Die()
    {
        isDead = true;
        randomAttackSound.Stop();
        wolfChase.Stop();
        agent.isStopped = true;
        wolfAnimator.Play("die");
        randomInt = Random.Range(0, 2);
        if (randomInt == 0)
        {
            randomDeathSound = wolfDeath1;
        }
        else
        {
            randomDeathSound = wolfDeath2;
        }

        randomDeathSound.Play();
        killCount++;

    }

    void Flee()
    {

    }



}

