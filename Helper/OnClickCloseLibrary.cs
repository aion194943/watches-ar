using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnClickCloseLibrary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CloseLibrary);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseLibrary( )
    {
        LoginManager.instance.HideCollectionWindow();

    }
}
