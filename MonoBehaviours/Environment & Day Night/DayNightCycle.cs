using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {
    public Material material;
    public float secondsInDay;
    public float currentTimeOfDay = 0;
    public float timeMultiplier;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        currentTimeOfDay += (Time.deltaTime / secondsInDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }

        if (Input.GetKeyDown(KeyCode.T) )
        {
            RenderSettings.ambientLight = Color.grey;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            RenderSettings.ambientLight = Color.white;
        }
    }
}
