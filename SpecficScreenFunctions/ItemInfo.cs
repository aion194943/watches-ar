using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public static ItemInfo instance;

    [Header("Images/Icons stuff")]
    public Sprite unsavedImageIcon;
    public Sprite savedImageIcon;

    public Image saveIconImage;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MarkSaveIcon( )
    {
        saveIconImage.sprite = savedImageIcon;
    }


    public void UnMarkSaveIncon( )
    {
        saveIconImage.sprite = unsavedImageIcon;
    }
}
