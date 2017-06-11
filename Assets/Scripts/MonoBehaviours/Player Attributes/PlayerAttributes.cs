using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    public float health, stamina, hunger, thirst, warmth;

    public float maxHealth, maxStamina, maxHunger, maxThirst, maxWarmth;

    public float healthRegenRate, staminaRegenRate, hungerRegenRate, thirstRegenRate, warmthRegenRate;

    public float healthDegenRate, staminaDegenRate, hungerDegenRate, thirstDegenRate, warmthDegenRate;

    public float temperature, minTolerableTemp, maxTolerableTemp;

    public bool fatigued, starved, parched, freezing;

    public float fatiguedDamageRate, starvedDamageRate, parchedDamageRate, freezingDamageRate;

    public GameObject deathFX;

    public playerHealth playerHealth;

    Vector2 previousPosition;

    // Use this for initialization
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStamina();
        UpdateHunger();
        UpdateThirst();
        UpdateWarmth();

        if (fatigued)
            AddDamage(fatiguedDamageRate * Time.deltaTime);
        if (starved)
            AddDamage(starvedDamageRate * Time.deltaTime);
        if (parched)
            AddDamage(parchedDamageRate * Time.deltaTime);
        if (freezing)
            AddDamage(freezingDamageRate * Time.deltaTime);
    }

    //if an increment is to be made run UpdateStamina(x, 0) once (meant to be used by pickup/item script)
    //if a steady increment is to be made run UpdateStamina(0,x) once where x is the rate per second
    //(meant to be used when the player enters a certain area that affects his stamina)
    //for example can be used when the player is moving through water or mud

    void UpdateStamina()
    {
        if (transform.position.x == previousPosition.x && transform.position.y == previousPosition.y)
            stamina += Mathf.Clamp(Time.deltaTime * staminaRegenRate, 0, maxStamina);
        else
        {
            stamina -= Mathf.Abs((transform.position.x - previousPosition.x) + (transform.position.y - previousPosition.y)) * staminaDegenRate;

        }
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        previousPosition = transform.position;
        if (stamina <= 0)
            fatigued = true;
        else
            fatigued = false;
    }
    void UpdateHunger()
    {
        hunger += hungerDegenRate * Time.deltaTime;
        hunger = Mathf.Clamp(hunger, 0, maxHunger);
        if (hunger >= maxHunger)
            starved = true;
        else
            starved = false;
    }

    void UpdateThirst()
    {
        thirst += thirstDegenRate * Time.deltaTime;
        thirst = Mathf.Clamp(thirst, 0, maxThirst);
        if (thirst >= maxThirst)
            parched = true;
        else
            parched = false;
    }

    void UpdateWarmth()
    {
        if (temperature < minTolerableTemp)
            warmth -= warmthDegenRate * Time.deltaTime * (minTolerableTemp - temperature);
        else if (temperature > maxTolerableTemp)
            warmth -= warmthDegenRate * Time.deltaTime * (maxTolerableTemp - temperature);
        warmth = Mathf.Clamp(warmth, 0, maxWarmth);
        if (warmth <= 0)
            freezing = true;
        else
            freezing = false;
    }


    //INCREMENTS ARE MEANT TO BE USED BY OTHER SCRIPTS (PICKUPS, DAMAGE etc)
    public void AddDamage(float increment)
    {
        /*
        health = Mathf.Clamp(health - increment, 0, maxHealth);
        if (health <= 0)
        {
            playerDie();
        }
        */
        playerHealth.addDamage(increment);

    }
    public void IncrementStamina(float increment)
    {
        stamina = Mathf.Clamp(stamina + increment, 0, maxStamina);
    }
    public void IncrementHunger(float increment)
    {
        hunger = (Mathf.Clamp(hunger + increment, 0, maxHunger));
    }
    public void IncrementThirst(float increment)
    {
        thirst = Mathf.Clamp(thirst + increment, 0, maxThirst);
    }

    public void SetTemperature(int temperature)
    {
        this.temperature = temperature;
    }

    public void playerDie()
    {
        //Instantiate( object to be instantiated, where/location to instantiate, rotation of object) 
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
