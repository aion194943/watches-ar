using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProfileWindow : MonoBehaviour
{
    public static ProfileWindow instance;
    public TextMeshProUGUI nameValue;
    public TextMeshProUGUI emailValue;
    public TextMeshProUGUI phoneValue;

    public Button logOutButton;
   
    void Awake( )
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        logOutButton.onClick.AddListener(LogOut);
    }

    // Update is called once per frame
    void Update()
    {
        if(AccountManager.instance.isAccountLoggedIn)
        {
            nameValue.text = AccountManager.instance.LoggedInAccount.AccountName;
            emailValue.text = AccountManager.instance.LoggedInAccount.AccountEmail;
            phoneValue.text = AccountManager.instance.LoggedInAccount.AccountPhone;
        }

    }

    void LogOut( )
    {
        AccountManager.instance.LogOut();
        LoginManager.instance.HideAllWindows();
    }
}
