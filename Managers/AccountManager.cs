using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Account
{
    public string AccountUserName;
    public string AccountName;
    public string AccountPassword;
    public string AccountEmail;
    public string AccountPhone;
    public bool isLoggedIn = false;
}

[System.Serializable]
public class AccountManager : MonoBehaviour
{
    public static AccountManager instance;
    public bool isAccountLoggedIn = false;
    public List<Account> Accounts;
    public Account LoggedInAccount;

    public List<GameObject> objectsToHideOnLogIn;


    public void LogOut( )
    {
        isAccountLoggedIn = false;
        LoggedInAccount = null;
        LogInWindow.instance.loginImageIcon.sprite = LogInWindow.instance.loggedOutSprite;
    }
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
       SaveData svData =  SaveSystem.instance.LoadGame();

        if(svData != null && svData.Accounts != null)
        {
            foreach (Account acc in svData.Accounts)
            {
                Accounts.Add(acc);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAccount(string name, string password, string email, string phone, string userName)
    {
        Account newAccount = new Account();
        newAccount.AccountName = name;
        newAccount.AccountPassword = password;
        newAccount.AccountEmail = email;
        newAccount.AccountPhone = phone;
        newAccount.AccountUserName = userName;
        bool canCreateAccount = true;
        foreach(Account acc in Accounts)
        {
            if(acc.AccountUserName == userName)
            {
                canCreateAccount = false;
            }
        }

        if(canCreateAccount)
        {
            Accounts.Add(newAccount);
        }
        else
        {
            //Debug.LogError("Account already exists!");
            CrackerNotification.instance.ShowCrackerMessage("Account Already Exists. Try a new name.");
        }
        SaveData svData = new SaveData();
        svData.Accounts = new List<Account>();
        foreach(Account acc in Accounts)
        {
            svData.Accounts.Add(acc);
        }
        SaveSystem.instance.SaveGame(svData);
    }

    public bool LogIntoAccount(string name, string password)
    {

        foreach(Account account in Accounts)
        {
            if(account.AccountUserName == name && account.AccountPassword == password)
            {
                LoggedInAccount = new Account();
                LoggedInAccount.AccountPassword = account.AccountPassword;
                LoggedInAccount.AccountName = account.AccountName;
                LoggedInAccount.AccountPhone = account.AccountPhone;
                LoggedInAccount.AccountEmail = account.AccountEmail;
                LoggedInAccount.AccountUserName = account.AccountUserName;
                LoggedInAccount.isLoggedIn = true;
                isAccountLoggedIn = true;
                DisableLogInWindow();
                LogInWindow.instance.loginImageIcon.sprite = LogInWindow.instance.loggedInSprite;
                CrackerNotification.instance.ShowCrackerMessage("Succesfully Logged in as: " + account.AccountUserName);
                return true;
            }
        }

        CrackerNotification.instance.ShowCrackerMessage("Wrong UserName or Password");
        return false;
    }

    public void DisableLogInWindow( )
    {
        foreach(GameObject obj in objectsToHideOnLogIn)
        {
            obj.SetActive(false);
        }
    }
}
