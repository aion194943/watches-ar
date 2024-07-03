using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectionEntry : MonoBehaviour
{
    int obID = 0;
    int coID = 0;
    public Image img;
    public OnClickOpenTryOnPopup button;
    public TextMeshProUGUI label;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetObjectData(Sprite image, string name)
    {
        img.sprite = image;
        label.text = name;
    }

    public void SetObjectID(int _obID, int coID)
    {
        button.SetButtonID(_obID, coID);
    }
}
