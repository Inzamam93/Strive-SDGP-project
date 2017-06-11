using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//using LitJson;
public class achievementsList : MonoBehaviour {
    //string jsonString;
    public Text achievementText;
    float steps;
    
	// Use this for initialization
	void Start () {
        //jsonString = File.ReadAllText(Application.dataPath);
        steps = 24;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setAchievement()
    {
        achievementText.text = "Total Steps : "+steps;
    }
}
