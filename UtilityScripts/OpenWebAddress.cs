using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenWebAddress : MonoBehaviour
{

    public string URL = "https://";
    Button clickButton;
    // Start is called before the first frame update
    void Start()
    {
        clickButton = transform.GetComponent<Button>();
        clickButton.onClick.AddListener(OpenURL);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenURL()
    {
        InAppBrowser.OpenURL(URL);
    }
}
