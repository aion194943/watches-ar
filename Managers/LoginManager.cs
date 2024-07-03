using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LoginManager : MonoBehaviour
{

    public static LoginManager instance;

    public GameObject homeScreen;
    public GameObject loginWindow;
    public GameObject signupWindow;
    public GameObject profileWindow;
    public GameObject arCamWindow;
    public GameObject arCamItemHolder;

    public List<GameObject> allWindows;


    public ARSession arSession;

    public GameObject TryOnPopUp;
    public GameObject collectionWindow;


    public GameObject trkObject;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        allWindows.Add(TryOnPopUp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHomeScreen( )
    {
        homeScreen.gameObject.SetActive(true);
        homeScreen.transform.SetAsLastSibling();
    }

    public void CloseHomeScreen( )
    {
        homeScreen.gameObject.SetActive(false);
    }

    public void OpenArCam( )
    {
        arCamWindow.gameObject.SetActive(true);
        arCamWindow.transform.SetAsLastSibling();
    }

    public void CloseArCam( )
    {
        arCamWindow.gameObject.SetActive(false);

    }
    public void ShowLoginWindow( )
    {
        HideAllWindows();
        loginWindow.SetActive(true);
        loginWindow.transform.SetAsLastSibling();

    }

    public void ShowSignupWindow( )
    {
        HideAllWindows();
        signupWindow.SetActive(true);
        signupWindow.transform.SetAsLastSibling();
    }

    public void ShowProfileWindow( )
    {
        HideAllWindows();
        profileWindow.SetActive(true);
    }
    public void HideAllWindows( )
    {
        foreach (GameObject obj in allWindows)
        {
            obj.SetActive(false);
        }

  
    }

    public void OpenTryOnPopup(bool openDeleteItem = false)
    {
        TryOnPopUp.transform.SetAsLastSibling();
        TryOnPopUp.gameObject.SetActive(true);
        if(openDeleteItem)
        {
            Debug.LogError("Also Open Item Holder");
            GetTryOnPopupObject().GetComponent<TryOnPopup>().OpenDeleteItemHolder();
            arCamItemHolder.SetActive(true);
        }
        else
        {
            GetTryOnPopupObject().GetComponent<TryOnPopup>().HideDeleteItemHolder();
            arCamItemHolder.SetActive(false);
        }
    }

    public GameObject GetTryOnPopupObject( )
    {
        return TryOnPopUp;
    }

    public void CloseTryOnPopup( )
    {
        TryOnPopUp.SetActive(false);
    }

    public void ShowCollectionWindow( )
    {
        collectionWindow.transform.SetAsLastSibling();
        SavedWindow.instance.LoadSavedObject();
        collectionWindow.SetActive(true);
    }

    public void HideCollectionWindow( )
    {
        collectionWindow.SetActive(false);
    }


    public void ResetARSession( )
    {
        //arSession.Reset();
        arSession.subsystem.Stop();
        arSession.subsystem.Start();

    }

    public GameObject GetTrkObject( )
    {
        return trkObject;
    }
}


