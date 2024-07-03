using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCollectionButton : MonoBehaviour
{
    public Button openButton;
    public List<GameObject> windowsToOpen;
    public List<GameObject> windowsToClose;
    // Start is called before the first frame update
    void Start()
    {
        openButton.onClick.AddListener(OpenCollectionClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenCollectionClick( )
    {
        if(AccountManager.instance.isAccountLoggedIn)
        {
            /*foreach(GameObject obj in windowsToOpen)
            {
                obj.SetActive(true);
            }*/
            LoginManager.instance.ShowCollectionWindow();
            SavedWindow.instance.LoadIntoCollectionForAccount();
            foreach (GameObject obj in windowsToClose)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            CrackerNotification.instance.ShowCrackerMessage("You need to login, first");
        }
    }
}
