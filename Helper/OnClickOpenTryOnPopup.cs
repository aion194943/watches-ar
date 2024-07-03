using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickOpenTryOnPopup : MonoBehaviour
{
    public int obID = 0;
    public int coID = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickAction( )
    {
        TrackingManager.instance.SetTrackedObject(ItemDataBase.instance.creatorList[obID].items[coID].arModel);
        LoginManager.instance.OpenTryOnPopup(true);
        LoginManager.instance.GetTryOnPopupObject().GetComponent<TryOnPopup>().SetButtonID(gameObject.transform.parent.GetSiblingIndex());
    }

    public void SetButtonID(int _obID, int _coID)
    {
        obID = _obID;
        coID = _coID;
    }    

}
