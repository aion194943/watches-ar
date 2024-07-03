using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnClickOpenTryOnPopupWithItemInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickOpenTryOnPopupItemInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickOpenTryOnPopupItemInfo( )
    {
        Debug.LogError("This was called properly");
        LoginManager.instance.OpenTryOnPopup(true);


  
    }

}
