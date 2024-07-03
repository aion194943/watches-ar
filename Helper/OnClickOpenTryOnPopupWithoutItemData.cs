using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickOpenTryOnPopupWithoutItemData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickOpenPopup);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickOpenPopup( )
    {
        LoginManager.instance.OpenTryOnPopup(false);
    }
}
