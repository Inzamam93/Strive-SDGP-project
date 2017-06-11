using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherTimeManager: MonoBehaviour {
    public PlayerAttributes playerAttributes;
    public float secondsInDay;
    public float currentTime;
    public float timeMultiplier;

    public float baseTemp;
    public float currentTemp;
    public float tempDeviation;

    public float tempIncrement = 0;

	void Update () {
        currentTime += (Time.deltaTime / secondsInDay) * timeMultiplier;

        if (currentTime >= 0.5)
        {
            currentTime = -0.5f;
        }

        currentTemp = baseTemp + (currentTime * tempDeviation) + tempIncrement;
        playerAttributes.SetTemperature((int)currentTemp);
    }

    public void SetTemperatureIncrement(float increment)
    {
        tempIncrement += increment;
    }

    public float GetTime()
    {
        return currentTime;
    }
    public int GetTemp()
    {
        return (int)currentTemp;
    }
}
