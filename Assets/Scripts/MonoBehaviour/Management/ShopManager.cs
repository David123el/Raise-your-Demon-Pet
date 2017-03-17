using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShopManager : MonoBehaviour
{
    private static string DataPath = string.Empty;

    public static ShopData shopData = new ShopData();

    //down below are all the GUI fields
    
    //e.g turn an item in shop available for purchase(new image + active button) if isUnlocked = true

    void Awake()
    {
        //DataPath = Path.Combine(Application.persistentDataPath, "Json/ShopData.json");
        DataPath = Path.Combine(Application.streamingAssetsPath, "Json/ShopData.json");
    }

	void Start ()
    {
        shopData.isUnlocked = false;
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shopData.isUnlocked = !shopData.isUnlocked;
            Save();
        }
        else if (Input.GetMouseButtonUp(0))
            Load();
    }

    public void UnlockItem()
    {
        if (shopData.isUnlocked)
        {
            print("unlock item in shop");
        }
    }

    public void Save()
    {
        JsonSave.Save(shopData, DataPath);
        print("Game Saved");
    }

    public void Load()
    {
        ShopData newShopData = new ShopData();
        object o = newShopData;
        JsonSave.Load(DataPath, ref o);

        print("Game Loaded " + shopData.isUnlocked);
    }
}

[System.Serializable]
public class ShopData
{
    public bool isUnlocked;
}
