using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class UserActivity : MonoBehaviour
{
    public static int steps = 17;
    public static int points;
    public Text heading;
    public Text maxHealth;
    public Slider maxHealthSlider;
    public Text maxStamina;
    public Slider maxStaminaSlider;

    ActivityRecord userActivity;
    // Use this for initialization
    void Start()
    {
        //StartCoroutine(GetHealthStatistics());
        displaySkills();
        points = steps;
        heading.text = "Points to be spent : " + steps;
    }

    IEnumerator GetHealthStatistics()
    {
        //sending a GET request
        string requestURL = "https://vimo-strive.firebaseio.com/.json";
        UnityWebRequest request = UnityWebRequest.Get(requestURL);
        yield return request.Send();

        if (request.error == null)
        {
            ParseJSON(request.downloadHandler.text);
        }
        else
        {
            Debug.Log(request.error);
            Debug.Log("Retrieving updated health statistics failed!");
        }
    }

    public void displaySkills()
    {
        //maxHealth.text = ""+100;
        //maxStamina.text = "" + 100;
        //maxHealthSlider.minValue = 0;
        //maxHealthSlider.maxValue = points - maxStaminaSlider.value;
        //maxStaminaSlider.minValue = 0;
        //maxStaminaSlider.minValue = points - maxHealthSlider.value;
        //heading.text = "Points to be spent : " + points;
    }

    public void onChangeMaxHealth() {
        points -= (int)maxHealthSlider.value;
        maxHealth.text = ""+ (100 + (int)maxHealthSlider.value);
        displaySkills();
    }
    public void onChangeMaxStamina()
    {
        points -= (int)maxStaminaSlider.value;
        maxStamina.text = "" + (100 + (int)maxStaminaSlider.value);
        displaySkills();
    }

    private void ParseJSON(string jsonContent)
    {
        userActivity = JsonMapper.ToObject<ActivityRecord>(jsonContent);
    }
}
public class ActivityRecord
{
    string userId;
    int steps;
}