using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogInWindow : MonoBehaviour
{
    public static LogInWindow instance;

    public Button LogInButton;
    public Button cancelButton;
    public Button signupButton;
    public Button closeButton;

    public TMP_InputField accountName;
    public TMP_InputField accountPassword;

    public Sprite loggedInSprite;
    public Sprite loggedOutSprite;
    public Image loginImageIcon;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        LogInButton.onClick.AddListener(LogInPressed);
        cancelButton.onClick.AddListener(CancelPressed);
        closeButton.onClick.AddListener(CloseButtonPressed);
        signupButton.onClick.AddListener(SignUpPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogInPressed( )
    {
        if(AccountManager.instance.LogIntoAccount(accountName.text, accountPassword.text) == true)
        {
            CloseButtonPressed();
        }
    }

    public void CancelPressed( )
    {

    }

    public void CloseButtonPressed( )
    {

    }

    public void SignUpPressed( )
    {
        LoginManager.instance.ShowSignupWindow();
    }

    private void OnEnable()
    {
        if(AccountManager.instance.isAccountLoggedIn)
        {
            gameObject.SetActive(false);
        }
    }
}
