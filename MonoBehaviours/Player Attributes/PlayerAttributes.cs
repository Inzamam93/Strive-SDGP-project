using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAttributes : MonoBehaviour
{
    [SerializeField]
    private float health, stamina, hunger, thirst, warmth;

    [SerializeField]
    private float maxHealth, maxStamina, maxHunger, maxThirst, maxWarmth;

    [SerializeField]
    private float healthRegenRate, staminaRegenRate, hungerRegenRate, thirstRegenRate, warmthRegenRate;

    [SerializeField]
    private float healthDegenRate, staminaDegenRate, hungerDegenRate, thistDegenRate, warmthDegenRate;

    public float temp, minTolerableTemp, maxTolerableTemp;

    public bool fatigued = false, starving = false, parched = false, freezing = false; 

    Vector2 previousPosition;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
        hunger = maxHunger;
        thirst = maxThirst;
        warmth = maxWarmth;
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateStamina();
        UpdateHunger();
        UpdateThirst();
        UpdateWarmth();
    }

    //if an increment is to be made run UpdateStamina(x, 0) once (meant to be used by pickup/item script)
    //if a steady increment is to be made run UpdateStamina(0,x) once where x is the rate per second
    //(meant to be used when the player enters a certain area that affects his stamina)
    //for example can be used when the player is moving through water or mud
    void UpdateHealth()
    {
        //if player is fatigued, starving, parched or freezing he loses health constantly
        if (fatigued || starving || parched || freezing)
        {
            health -= healthDegenRate * Time.deltaTime;
        }
    }
    void UpdateStamina()
    {
        stamina += Mathf.Abs((transform.position.x - previousPosition.x) + (transform.position.y - previousPosition.y)) * staminaDegenRate;
        Mathf.Clamp(stamina, 0, 100);
        previousPosition = transform.position;
    }
    void UpdateHunger()
    {
        hunger += hungerDegenRate * Time.deltaTime;
    }

    void UpdateThirst()
    {
        hunger += hungerDegenRate * Time.deltaTime;
    }

    void UpdateWarmth()
    {
        if (temp < minTolerableTemp)
            warmth += warmthDegenRate * Time.deltaTime * (minTolerableTemp - temp);
        else if (temp > maxTolerableTemp)
            warmth += warmthDegenRate * Time.deltaTime * (maxTolerableTemp - temp);

    }


    //INCREMENTS ARE MEANT TO BE USED BY OTHER SCRIPTS (PICKUPS, DAMAGE etc)
    public void IncrementHealth(float increment)
    {
        health = Mathf.Clamp(health + increment, 0, maxHealth);
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
        thirst = Mathf.Clamp(hunger + increment, 0, maxThirst);
    }
}
