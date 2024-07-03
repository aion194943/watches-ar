using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

[System.Serializable]
public class svItemData
{
    public string AccountUserName = "";
    public string name = "";
    public int cIDX = 0;
    public int iIDX = 0;
}
[System.Serializable]
public class SaveData
{
    public List<Account> Accounts;
    public List<svItemData> savedItems;

    public SaveData( )
    {
        savedItems = new List<svItemData>();
    }
}
public class SaveSystem : MonoBehaviour
{
    public List<svItemData> savedItems;
    // Makes it a singleton / single instance
    static public SaveSystem instance;
    string filePath;

    private void Awake()
    {
        // Check there are no other instances of this class in the scene
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "/save.data";
        
    }

    public void SaveGame(SaveData saveData)
    {
        FileStream dataStream = new FileStream(filePath, FileMode.Create);
        
        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, saveData);

        dataStream.Close();
    }

    public void AddItemToSaveList(int creatorIDX, int itmIDX)
    {
        svItemData itm = new svItemData();
        itm.name = ItemDataBase.instance.creatorList[creatorIDX].items[itmIDX].Name;
        itm.AccountUserName = AccountManager.instance.LoggedInAccount.AccountUserName;
        itm.cIDX = creatorIDX;
        itm.iIDX = itmIDX;
        savedItems.Add(itm);
    }

    public void DeleteProgress( )
    {
        if(File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
    public SaveData LoadGame()
    {
        if (File.Exists(filePath))
        {
            // File exists 
            FileStream dataStream = new FileStream(filePath, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();
            SaveData saveData = converter.Deserialize(dataStream) as SaveData;

            foreach (svItemData svItm in saveData.savedItems)
            {
                Debug.LogError("Object name in here: " + svItm.cIDX);
            }
            dataStream.Close();
            return saveData;
        }
        else
        {
            // File does not exist
            Debug.LogError("Save file not found in " + filePath);
            return null;
        }
    }
}