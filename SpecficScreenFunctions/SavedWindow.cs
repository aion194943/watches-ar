using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedWindow : MonoBehaviour
{
    public static SavedWindow instance;

    public Transform holder;
    public GameObject templateEntry;

    [SerializeField]
    public List<svItemData> savedItems;
    public List<GameObject> savedButtons;



    List<GameObject> hackObjectPosition;
    bool saveLoaded = false;
    void Awake( )
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SaveSystem.instance != null)
        {

            SaveData newData = SaveSystem.instance.LoadGame();
            if (newData != null)
            {
                Debug.LogError("Not null, stuff exists we should be good");
                foreach (svItemData itm in newData.savedItems)
                {
                    Debug.LogError("ITM IN SAVE FILE: " + itm.name);
                    svItemData item = new svItemData();
                    item.AccountUserName = itm.AccountUserName;
                    item.name = itm.name;
                    item.cIDX = itm.cIDX;
                    item.iIDX = itm.iIDX;
                    savedItems.Add(item);

                }

            }
        }

    }

    void OnEnable( )
    {

    }

    IEnumerator LoadSavedCollection( )
    {
        yield return new WaitForSeconds(1.1f);
 


    }


    public void LoadSavedObject( )
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void LoadIntoCollectionForAccount( )
    {
        for(int i = 1; i < holder.childCount; i++)
        {
            Destroy(holder.GetChild(i).gameObject);
        }
        foreach(svItemData itm in savedItems)
        {

            if(itm.AccountUserName == AccountManager.instance.LoggedInAccount.AccountUserName)
            {
                GameObject newObject = Instantiate(templateEntry, holder.position, Quaternion.identity);
                newObject.transform.parent = holder.transform;
                newObject.SetActive(true);
                newObject.transform.localScale = Vector3.one;

                Item item = HomeScreen.instance.GetItemFor(itm.cIDX, itm.iIDX);
                newObject.GetComponent<CollectionEntry>().SetObjectData(item.itemPicture, item.Name);
                newObject.GetComponent<CollectionEntry>().SetObjectID(itm.cIDX, itm.iIDX);
                itm.AccountUserName = AccountManager.instance.LoggedInAccount.AccountUserName;
            }

        }
    }

    public void AddToCollection(svItemData itm)
    {


        if (DoesSavedItemsContain(itm))
        {
            CrackerNotification.instance.ShowCrackerMessage("Item already exists in user library");
        }
        else
        {
            itm.AccountUserName = AccountManager.instance.LoggedInAccount.AccountUserName;
            savedItems.Add(itm);

            SaveData svData = new SaveData();
            svData.Accounts = new List<Account>();
            foreach (Account acc in AccountManager.instance.Accounts)
            {
                svData.Accounts.Add(acc);
            }
            svData.savedItems = new List<svItemData>();


            if(DoesSavedGameItemDataContain(itm) == false)
            {
                foreach (svItemData items in savedItems)
                {
                    svData.savedItems.Add(items);
                }

                SaveSystem.instance.SaveGame(svData);
            }


            
        }


    }

    void RefreshContent( )
    {
        Debug.LogError("Refreshed is called");
        foreach (svItemData itm in  savedItems)
        {
            svItemData item = new svItemData();
            item.name = itm.name;
            item.cIDX = itm.cIDX;
            item.iIDX = itm.iIDX;
            AddToCollection(item);
        }
    }

    public void DeleteFromCollection(int id)
    {
        if(id < savedItems.Count)
        {
            savedItems.RemoveAt(id-1);
            Destroy(holder.transform.GetChild(id).gameObject);

        }
    }



    public bool DoesSavedItemsContain(svItemData itm)
    {
        foreach(svItemData svItm in savedItems)
        {
            if(itm.name == svItm.name)
            {
                return true;
            }
        }
        return false;
    }

    public bool DoesSavedItemsContainForCurrentAccount(svItemData itm)
    {
        foreach (svItemData svItm in savedItems)
        {
            if(svItm.AccountUserName == AccountManager.instance.LoggedInAccount.AccountUserName)
            {
                if (itm.name == svItm.name)
                {
                    return true;
                }
            }

        }
        return false;
    }


    bool DoesSavedGameItemDataContain(svItemData itm)
    {
        foreach (svItemData svItm in SaveSystem.instance.savedItems)
        {
            if (itm.name == svItm.name)
            {
                return true;
            }
        }
        return false;
    }
}
