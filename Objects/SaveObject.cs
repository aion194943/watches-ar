using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveObject : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SaveObjectToCollection);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(AccountManager.instance != null)
        {
            if(AccountManager.instance.isAccountLoggedIn)
            {
                UpdateIcon();
            }
            else
            {
                ItemInfo.instance.UnMarkSaveIncon();
            }
        }
        

    }

    void UpdateIcon( )
    {

        if (SavedWindow.instance.DoesSavedItemsContainForCurrentAccount(HomeScreen.instance.GetCurrentItem()))
        {
            ItemInfo.instance.MarkSaveIcon();
        }
        else
        {
            ItemInfo.instance.UnMarkSaveIncon();
        }

    }

    void SaveObjectToCollection( )
    {

        if(AccountManager.instance.isAccountLoggedIn)
        {
            //ItemInfo.instance.MarkSaveIcon();
            HomeScreen.instance.gameObject.SetActive(true);
            SavedWindow.instance.AddToCollection(HomeScreen.instance.GetCurrentItem());
            HomeScreen.instance.gameObject.SetActive(false);
        }
        else
        {
            CrackerNotification.instance.ShowCrackerMessage("You need to be logged in to save");
        }

    }


}
