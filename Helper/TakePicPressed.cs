using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TakePicPressed : MonoBehaviour
{
    public RawImage rt;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnTakePicPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTakePicPressed( )
    {
        PicTakenWindow.instance.ShowWindow();
        PicTakenWindow.instance.TakeScreenshot(rt.mainTexture);
    }
}
