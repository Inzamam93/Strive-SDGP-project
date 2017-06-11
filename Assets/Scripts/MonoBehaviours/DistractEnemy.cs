using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractEnemy : MonoBehaviour {
    public List<EnemyState> enemies;
    public Vector2 noiseLocation;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerManager.enemies)
        {
            if (!enemies.Contains(collider.gameObject.GetComponent<EnemyState>()))
            {
                enemies.Add(collider.gameObject.GetComponent<EnemyState>());
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerManager.enemies)
        {
            enemies.Remove(collider.GetComponent<EnemyState>());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        noiseLocation = transform.position;
        foreach (EnemyState enemyState in enemies)
        {

        }
    }
}
