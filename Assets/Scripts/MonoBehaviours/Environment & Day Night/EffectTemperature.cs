using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EffectTemperature : MonoBehaviour {
    public WeatherTimeManager weatherTimeManager;
    public int tempIncrement;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerManager.playerActive || collider.gameObject.layer == LayerManager.playerHidden)
        {
            weatherTimeManager.SetTemperatureIncrement(tempIncrement);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerManager.playerActive || collider.gameObject.layer == LayerManager.playerHidden)
        {
            weatherTimeManager.SetTemperatureIncrement(-tempIncrement);
        }
    }
}
