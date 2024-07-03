using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignupWindow : MonoBehaviour
{
    public static SignupWindow instance;
    
    public TMP_InputField Name;
    public TMP_InputField surname;
    public TMP_InputField birthday;
    public TMP_InputField phoneNumber;
   
    public TMP_InputField email;
    public TMP_InputField accountName;
    public TMP_InputField password;

    public Button signUpButton;
    public Button closeButton;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        signUpButton.onClick.AddListener(SignUpPressed);
        closeButton.onClick.AddListener(CloseButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SignUpPressed( )
    {
        AccountManager.instance.AddAccount(Name.text, password.text, email.text, phoneNumber.text, accountName.text);
        //LoginManager.instance.ShowProfileWindow();
        LoginManager.instance.HideAllWindows();
    }

    public void CloseButtonPressed( )
    {
        LoginManager.instance.HideAllWindows();
    }
}
