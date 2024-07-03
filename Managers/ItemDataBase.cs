using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Creator
{
    public string Name;
    public string BrandDescription;
    public string CreatorWebsite;
    public string ContactEmail;
    public List<Item> items;
}

[System.Serializable]
public class Item
{
    public string Name;
    public string ItemDescription;
    public string Material;
    public Sprite itemPicture;
    public GameObject itemModel;
    public GameObject arModel;
}


public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;

    public List<Creator> creatorList;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
