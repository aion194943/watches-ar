using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickDeleteFromLibrary : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnDeleteClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDeleteClicked( )
    {
        SavedWindow.instance.DeleteFromCollection(TryOnPopup.instance.orderIDX);
    }
}
