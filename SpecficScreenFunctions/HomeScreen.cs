using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class HomeScreen : MonoBehaviour
{
    public static HomeScreen instance;

    public TextMeshProUGUI CreatorName;
    public TextMeshProUGUI ItemName;

    public Button itemInfoButton;

    public Button leftArrowItem;
    public Button rightArrowItem;
    public Button upArrrowCreator;
    public Button downArrowCreator;
    public Image itemPictureImage;

    [Header("ItemInfo Elements------")]
    public TextMeshProUGUI info_itemName;
    public TextMeshProUGUI info_creatorName;
    public TextMeshProUGUI info_itemDescription;
    public TextMeshProUGUI info_materialDescription;

    //Private - hidden
    public int creatorIDX = 0;
    public int itemIDX = 0;
    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        itemInfoButton.onClick.AddListener(OnItemInfoPressed);

        leftArrowItem.onClick.AddListener(OnLeftArrowPressed);
        rightArrowItem.onClick.AddListener(OnRightArrowPressed);
        upArrrowCreator.onClick.AddListener(OnUpArrowPressed);
        downArrowCreator.onClick.AddListener(OnDownArrowPressed);

        UpdateItemInformation(creatorIDX, itemIDX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnItemInfoPressed( )
    {

    }

    void UpdateItemInformation(int cIDX, int iIDX)
    {
        Debug.LogError("============================");
        Debug.LogError("This is called");

        LoginManager.instance.ResetARSession();
        CreatorName.text = ItemDataBase.instance.creatorList[cIDX].Name;
        ItemName.text = ItemDataBase.instance.creatorList[cIDX].items[iIDX].Name;


        info_itemName.text = ItemDataBase.instance.creatorList[cIDX].items[iIDX].Name;
        info_creatorName.text = ItemDataBase.instance.creatorList[cIDX].Name;
        info_itemDescription.text = ItemDataBase.instance.creatorList[cIDX].items[iIDX].ItemDescription;
        info_materialDescription.text = ItemDataBase.instance.creatorList[cIDX].items[iIDX].Material;

        itemPictureImage.sprite = ItemDataBase.instance.creatorList[cIDX].items[iIDX].itemPicture;

        ObjectCameraController.instance.Spawn3DModelIntoView(ItemDataBase.instance.creatorList[cIDX].items[iIDX].itemModel);

        CanvasDebugger.instance.SetText("Changed tracked object to: " + ItemDataBase.instance.creatorList[cIDX].items[iIDX].arModel.name);
        TrackingManager.instance.SetTrackedObject(ItemDataBase.instance.creatorList[cIDX].items[iIDX].arModel);

        creatorIDX = cIDX;
        itemIDX = iIDX;
    }


    public svItemData GetCurrentItem( )
    {
        Debug.LogError("Creator ID: " + creatorIDX + " ITEM IDX: " + itemIDX);
        svItemData itm = new svItemData();
        itm.name = ItemDataBase.instance.creatorList[creatorIDX].items[itemIDX].Name;
        itm.cIDX = creatorIDX;
        itm.iIDX = itemIDX;
        return itm;
    }

    public Item GetItemFor(int cIDX, int iIDX)
    {
        return ItemDataBase.instance.creatorList[cIDX].items[iIDX];
    }

    public void OnLeftArrowPressed( )
    {
        itemIDX--;
        if(itemIDX < 0)
        {
            itemIDX = ItemDataBase.instance.creatorList[creatorIDX].items.Count - 1;
        }

        UpdateItemInformation(creatorIDX, itemIDX);
    }

    public void OnRightArrowPressed( )
    {
        itemIDX++;
        if(itemIDX > ItemDataBase.instance.creatorList[creatorIDX].items.Count-1)
        {
            itemIDX = 0;
        }

        UpdateItemInformation(creatorIDX, itemIDX);
    }

    public void OnUpArrowPressed( )
    {
        creatorIDX--;
        itemIDX = 0;
        if (creatorIDX < 0)
        {
            creatorIDX = ItemDataBase.instance.creatorList.Count - 1;
        }

        UpdateItemInformation(creatorIDX, itemIDX);
    }

    public void OnDownArrowPressed( )
    {



        creatorIDX++;
        itemIDX = 0;
        if (creatorIDX > ItemDataBase.instance.creatorList.Count - 1)
        {
            creatorIDX = 0;
        }

        UpdateItemInformation(creatorIDX, itemIDX);
    }
}
