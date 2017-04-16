using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class EnemyState : MonoBehaviour {
    public Transform player;
    public bool playerSpotted;
    public bool playerInSight;
    public Transform lastSeen;
    public EnemyState enemyState;

    public float spottingRange;
    public float spottingTime;

    public float enemyHealth;
    public float maxEnemyHealth;
	// Use this for initialization
    
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {

        }
    }
}
enum EnemyType
{
    patrolling,

}
enum State{
    patrolling,
    spotted,
    vigilant,
    running,
    shooting,
    attacking
}
