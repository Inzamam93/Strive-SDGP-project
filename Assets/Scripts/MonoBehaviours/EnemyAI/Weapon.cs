using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public WeaponType weaponType;
    public Weapon CurrentWeapon;
	// Use this for initialization
	void Start () {
        //CurrentWeapon =  MeeleWeapon();
	}
	
    void setMeelee()
    {
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
public enum WeaponType
{
    Meelee,
    Bow,
    Gun
}
class MeeleWeapon : Weapon
{
    public float weaponRange;
    public float weaponDamage;
    public float swingTime;
    public float rechargeTime;
}

class BowAndArrow : Weapon
{
    public float projectileSpeed;
    public float dropoffGravity;
    public float weaponDamage;
    public float rechargeTime;
    public float ammo;
    public float accuracyPercentage;
}

class Gun : Weapon
{
    public float projectileSpeed;
    public float weaponDamage;
    public float reloadTime;
    public float rateOfFire;
}
