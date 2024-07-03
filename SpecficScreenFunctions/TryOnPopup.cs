using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryOnPopup : MonoBehaviour
{
    public static TryOnPopup instance;

    public GameObject deleteItemHolder;
    public Button deleteObjectButton;

    public int orderIDX = 0;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDeleteItemHolder( )
    {
        Debug.LogError("DeleteItem Holder should be active");
        //deleteItemHolder.SetActive(true);
    }

    public void HideDeleteItemHolder( )
    {
        Debug.LogError("DeleteItem holder should not be active");
        //deleteItemHolder.SetActive(false);
    }


    public void SetButtonID(int id)
    {
        orderIDX = id;
    }

    void DeleteObject( )
    {

    }

}
