using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnClickOpenARCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickOpen( )
    {
        //HomeScreen.instance.O
        LoginManager.instance.CloseHomeScreen();
        LoginManager.instance.CloseTryOnPopup();
        LoginManager.instance.OpenArCam();

    }
}
