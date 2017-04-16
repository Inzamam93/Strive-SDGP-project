using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class HealthDatabase : MonoBehaviour {

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {

        }
    }
}

public class HealthStats
{
    public int id { get; set; }
    public int stepsWalked { get; set; }
    public int stepsWalkedAverage { get; set; }

}
