using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyState : MonoBehaviour
{
    //player
    public Transform player;
    public PlayerState playerState;
    public Transform lastSeenPosition;
    public bool inRange;
    public bool investigatingNoise;
    public bool isSpotted = false;

    //enemy attributes
    //enemy state describes the different states the enemy can be in (patrolling, vigilant, attacking)
    public State enemyState;
    public float enemyHealth;
    public float maxEnemyHealth;
    public bool isRunning;
    public float walkSpeed = 3;

    public Image detectionBar;

    //spotting
    //reaction time is the time the enemy takes to register the player, fast movements arent registered, mimicking human behaviour
    public float reactionTime;
    //time seen is the time that the user has been seen for
    public float timeSeen = 0f;
    //time heard is the time that the user has been seen for
    public float timeHeard = 0f;
    //time that the enemy needs to see the player to spot him
    public float timeToSpotPlayer;
    //the coroutine that handles spotting
    private IEnumerator spot;
    //how much the enemy's head is offset from the center of the gameobject for more accurate raycasts when spotting
    public Vector2 headOffset;
    //how much the enemy's head is offset from the center of the gameobject for more accurate raycasts when shooting
    public Vector2 gunOffset;

    //array containing points which the enemy patrols
    public Vector2[] wayPoints;

    //shooting
    public float bulletDamage;
    public float innacuracyAngle;
    public float rateOfFire;
    public float timeSinceLastShot = 0;

    void Awake()
    {
        spot = Spot();
        isRunning = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //if the Coroutine is already running, we let it run. Prevents multiple coroutines from 'stacking'
        if (collider.gameObject.layer == LayerManager.playerActive)
        {
            Debug.Log("k");
            inRange = true;
            if (!isRunning)
            {
                spot = Spot();
                StartCoroutine(spot);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        //if the player leaves his sight then set the enemies current state to vigilant
        //the player could only have either been attacking at this time
        inRange = false;
    }

    public void InvestigateNoise(Vector2 noiseLocation)
    {
        //Debug.Log();
        //if the enemy is patrolling

    }

    /*
    public IEnumerator InvestigateNoise(Vector2 noiseLocation)
    {
        //Add while loop that runs till a path is not found or till the destination is reached or the time runs out

        Debug.Log("investigatingNoise");
        if (!enemyState.Equals(State.attacking) && !playerState.isSpotted())
        {
            timeHeard = timeToSpotPlayer;
            while (!enemyState.Equals(State.attacking) && !playerState.isSpotted() && timeHeard > 0)
            {
                Rigidbody2D EnemyRigid = gameObject.GetComponent<Rigidbody2D>();
                if (transform.position.x > noiseLocation.x)
                {
                    EnemyRigid.AddForce(new Vector2(walkSpeed, 0));
                }
                else
                {
                    EnemyRigid.AddForce(new Vector2(-walkSpeed, 0));
                }
                Debug.Log("Investigating noise");
                yield return null;
            }
            Debug.Log("Investigating noise!!");
        }
        yield break;
    }
    */
    IEnumerator Spot()
    {
        Debug.Log("Coroutine has started");
        isRunning = true;
        //if the player is in range draw a raycast, else stop the loop ELSE if the enemy is still vigilant, reduce the spottedTime till it reaches zero
        while (inRange || timeSeen > 0)
        {
            //if enemy is inRange, draw raycasts
            if (inRange && player !=null)
            {
                Debug.Log("Yes");
                //direction is used to cast rays, calculated each iteration
                Vector2 direction = player.transform.position - transform.position;
                //rays is cast in the direction of the player
                //Debug.DrawRay(transform.position, direction, Color.green, 0.03f);
                RaycastHit2D hitInfo = (Physics2D.Raycast(transform.position, direction, 100, 1 << LayerManager.playerActive | 1 << LayerManager.interactibles | 1 << LayerManager.platform));
                Debug.Log("Ray hit " + hitInfo.collider.gameObject.layer + " == " + LayerManager.playerActive + " " + (hitInfo.collider.gameObject.layer == LayerManager.playerActive));
                //Debug.Log("Layer of collided: " + hitInfo.collider.gameObject.layer + " Layer playeractive: " + LayerManager.playerActive + (hitInfo.collider.gameObject.layer == LayerManager.playerActive));
                if (hitInfo.collider.gameObject.layer == LayerManager.playerActive)
                {
                    if (playerState.isLit())
                    {
                        Debug.Log("Player is lit");
                        //if the player is already attacking and the player is visible and the player is lit, nothing needs to happens
                        if (enemyState.Equals(State.attacking))
                        {
                            Debug.Log("Player continues attacking");
                            playerState.SetSpotted(true);
                            isSpotted = true;
                        }
                        else
                        {
                            enemyState = State.vigilant;
                            playerState.SetSpotted(false);
                            isSpotted = false;
                            timeSeen = Mathf.Clamp(timeSeen += Time.deltaTime, 0, timeToSpotPlayer);
                            Debug.Log("Player is lit and not attacking yet" + Time.deltaTime);
                            //if the time taken to identify and attack is reached, then set state to attacking
                            if (timeSeen >= timeToSpotPlayer)
                                enemyState = State.attacking;
                        }
                    }
                    else
                    {
                        //if player is not lit he is automatically not spotted
                        playerState.SetSpotted(false);
                        isSpotted = false;
                        //if player was attacking when the player hid
                        switch (enemyState)
                        {
                            //if the enemy was attacking when the enemy was no longer lit, then he should be vigillant and start counting down the timeSeen
                            case State.attacking:
                                playerState.SetSpotted(false);
                                isSpotted = false;
                                enemyState = State.vigilant;
                                timeSeen = Mathf.Clamp(timeSeen -= Time.deltaTime, 0, timeToSpotPlayer);
                                break;
                            case State.vigilant:
                                enemyState = State.vigilant;
                                timeSeen = Mathf.Clamp(timeSeen -= Time.deltaTime, 0, timeToSpotPlayer);
                                if (timeSeen <= 0)
                                    enemyState = State.patrolling;
                                break;
                        }
                    }
                }
                else
                //if enemy is not in range, then start counting down if enemy was in either an attacking or vigilant state. If state was patrolling, dont do anything
                {
                    playerState.SetSpotted(false);
                    isSpotted = false;
                    switch (enemyState)
                    {
                        //if the enemy was attacking when the enemy was no longer lit, then he should be vigillant and start counting down the timeSeen
                        case State.attacking:
                            playerState.SetSpotted(false);
                            isSpotted = false;
                            enemyState = State.vigilant;
                            timeSeen = Mathf.Clamp(timeSeen -= Time.deltaTime, 0, timeToSpotPlayer);
                            break;
                        case State.vigilant:
                            enemyState = State.vigilant;
                            timeSeen = Mathf.Clamp(timeSeen -= Time.deltaTime, 0, timeToSpotPlayer);
                            break;
                    }
                }
            }
            else
            {
                playerState.SetSpotted(false);
                isSpotted = false;
                switch (enemyState)
                {
                    //if the enemy was attacking when the player moved out of range, then the enemy should be vigillant and start counting down the timeSeen
                    case State.attacking:
                        playerState.SetSpotted(false);
                        enemyState = State.vigilant;
                        timeSeen = Mathf.Clamp(timeSeen -= Time.deltaTime, 0, timeToSpotPlayer);
                        break;
                    case State.vigilant:
                        enemyState = State.vigilant;
                        timeSeen = Mathf.Clamp(timeSeen -= Time.deltaTime, 0, timeToSpotPlayer);
                        break;
                }
            }
            yield return null;
        }
        enemyState = State.patrolling;
        isRunning = false;
        yield break;
    }
    void Shoot(Vector2 targetDirection)
    {
        if (enemyState.Equals(State.attacking))
        {
            float degree = Vector2.Angle(player.transform.position, transform.position);
            degree += Random.Range(0, innacuracyAngle);
            Vector2 direction = DegreeToVector2(degree);

            //
            RaycastHit2D hitInfo = (Physics2D.Raycast(transform.position, targetDirection, 100, 1 << LayerManager.platform | 1 << LayerManager.interactibles | 1 << LayerManager.playerActive));
            Debug.DrawRay(transform.position, targetDirection, Color.red, 0.5f);
            //Debug.DrawLine(transform.position, targetDirection, Color.red, 0.3f);
            if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player"))
            {
                player.GetComponent<PlayerAttributes>().AddDamage(bulletDamage);
                Debug.Log("Hit Player");
            }
        }
    }

    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }

    void Update()
    {
        //rate of fire
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= 1f / rateOfFire)
        {
            if (enemyState.Equals(State.attacking) && inRange)
                Shoot(player.transform.position - transform.position);
            timeSinceLastShot = 0;
        }

        detectionBar.fillAmount = timeSeen / timeToSpotPlayer;
    }
    public State getState()
    {
        return enemyState;
    }
}
public enum State
{
    patrolling,
    vigilant,
    attacking
}


