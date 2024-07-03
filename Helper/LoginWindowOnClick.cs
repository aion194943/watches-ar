using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginWindowOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectWindow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectWindow( )
    {
        if(AccountManager.instance.isAccountLoggedIn == false)
        {
            HomeScreen.instance.gameObject.SetActive(true);
            LogInWindow.instance.gameObject.SetActive(true);
        }
        else
        {
            HomeScreen.instance.gameObject.SetActive(true);
            LoginManager.instance.ShowProfileWindow();
        }

    }
}
