using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
//gives access to lists 
using System.Collections.Generic;
//allows you to read files
using System.IO;
using UnityEditor;

public class ItemDatabase : MonoBehaviour {
    //going to store all items in the database
    private List<Item> database = new List<Item>();
    //holds actual JSON data that we pull in from the string
    private JsonData itemData;

    void Start()

    {        
        //READING FROM JSON FILE
        //allows you to take an C# object to JSON object and vice versa
        //dataPath gives path to asset folder no matter what the build platform is and allows editing of the file without recompiling the game
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        
        //CONSTRUCTING DATABASE ARRAY OF ITEMS
        //loops through itemData and adds to the database variable
        ConstructItemDatabase();
    }



    //loops through itemData and adds to the database variable
    void ConstructItemDatabase()
    {
        //go through each value we got
        //taking list with JSON data and looping through each item
        for (int i = 0; i < itemData.Count; i++)
        {
            //casting JSON data to string, and ints
            database.Add(new Item(
                (int)itemData[i]["id"], (itemData[i]["title"]).ToString(), (int)itemData[i]["value"], (int)itemData[i]["stats"]["power"],
                (int)itemData[i]["stats"]["defence"], (int)itemData[i]["stats"]["vitality"], itemData[i]["description"].ToString(),
                (bool)itemData[i]["stackable"], (int)itemData[i]["rarity"], itemData[i]["slug"].ToString(), itemData[i]["prefabName"].ToString()
                ));
        }
    }

    public List<Item> getDatabase()
    {
        return database;
    }

    public Item FetchItemById(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
                return database[i];
        return null;
    }
}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Power { get; set; }
    public int Defence { get; set; }
    public int Vitality { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }
    public Transform prefab { get; set; }

    public Item(int id, string title, int value, int power, int defence, int vitality, string description, bool stackable, int rarity, string slug, string prefabName )
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Power = power;
        this.Defence = defence;
        this.Vitality = vitality;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite> ("Sprites/Inventory/Items/" + slug);
        Sprite spritecheck = Resources.Load<Sprite>("Sprites/Inventory/Items/" + slug);
        if (spritecheck == null)
            Debug.Log("/Sprites/Inventory/Items/" + slug);
        this.prefab = (Transform)AssetDatabase.LoadAssetAtPath("Assets/prefabs/Inventory/Items" + prefabName, typeof(Transform));
        if (prefab == null)
            Debug.Log("Item prefab failed to load: " + "Assets/prefabs/Inventory/Items" + prefabName);
    }

    public void instantiatePrefab()
    {

    }

    public void destroyPrefab()
    {

    }

    public Item()
    {
        //Will let us know if  theres an error
        this.ID = -1;
    }

}
