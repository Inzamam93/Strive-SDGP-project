using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class EditModeTest : MonoBehaviour {
    JsonData itemData;
    int c = 0;

    void Update()
    {
        if (c % 7 == 0)
        {
            //READING FROM JSON FILE
            //allows you to take an C# object to JSON object and vice versa
            //dataPath gives path to asset folder no matter what the build platform is and allows editing of the file without recompiling the game
            itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemTest.json"));

            //CONSTRUCTING DATABASE ARRAY OF ITEMS
            //loops through itemData and adds to the database variable
            ConstructItemDatabase();
        }
        c++;
    }



    //loops through itemData and adds to the database variable
    void ConstructItemDatabase()
    {
        //go through each value we got
        //taking list with JSON data and looping through each item
        for (int i = 0; i < itemData.Count; i++)
        {
            //casting JSON data to string, and ints
            //Debug.Log((int)itemData[i]["id"] + " " + (itemData[i]["title"]).ToString());
        }
    }
}
