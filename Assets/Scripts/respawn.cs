using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour {
    bool respawnNow;
    public float restartTime;
    float resetTime;
	// Use this for initialization
	void Start () {
        respawnNow = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (respawnNow == true && resetTime <= Time.time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            
    }

    public void restartLevel()
    {
        respawnNow = true;
        resetTime = Time.time + restartTime;
  
        
    }
}
