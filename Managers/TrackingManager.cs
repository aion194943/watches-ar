using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class TrackingManager : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    public Transform trackedObjectAnchor;
    public GameObject trackedObject;
    public GameObject referencedObject;
    public static TrackingManager instance;
    ARTrackedImage temp;
    ARTrackedImageManager m_TrackedImageManager;



    public Vector3 newRotation;

    string initialTextLine = "";
    string inUpdateTextLine = "";
    string thirdUpdateTextLine = "";
    string modelName = "";

    int trackedObjectCounter = 0;
    int referenceTrackObjectCounter = 0;
    void Awake()
    {
        instance = this;
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        //if (trackedObject != null)
            //Destroy(trackedObject.transform.parent.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        debugText.text = "Model Name: "+modelName+"" + initialTextLine + "\n ====== \n" + inUpdateTextLine + "\n =========\n" + thirdUpdateTextLine + "";

        if(temp != null)
        {
            inUpdateTextLine = "Image size: x: " + temp.size.x + " y: " + 1 + " z:" + temp.size.y +
                 "\n | Scale X: " + temp.transform.localScale.x + " Y: " + temp.transform.localScale.y +
                    " Scale Z: " + temp.transform.localScale.z;


            thirdUpdateTextLine = "" + temp.trackingState.ToString();
        }
        else
        {
            inUpdateTextLine = "No Image";
        }

       
    }


    public void SetTrackedObject(GameObject obj)
    {
        trackedObjectCounter++;
        //referencedObject = TrackingPrefabUpdater.instance.gameObject;
        if (TrackingPrefabUpdater.instance != null)
        {
            TrackingPrefabUpdater.instance.SetReferenceObject(obj);
        }
        else
        {
            CanvasDebugger.instance.SetText("Tracked Object Instance is null");
        }


        
    }

    void ImageDetected(ARTrackedImage trackedImage)
    {
        /*if (trackedObject != null)
        {
            Destroy(trackedObject);
        }*/
        TrackingPrefabUpdater.instance.arImageGameObject = trackedImage.gameObject;

        trackedObject = TrackingPrefabUpdater.instance.SpawnNewObject();  // Instantiate(LoginManager.instance.GetTrkObject(), trackedImage.transform.position, Quaternion.identity);
        temp = trackedImage;
        if (trackedObject != null)
        {
            CanvasDebugger.instance.SetText("{CIP 2}: Spawned tracked object: " + trackedObject.name + "");
            trackedObject.transform.localScale = new Vector3(1f, 1f, 1f);
            trackedObject.layer = trackedObjectAnchor.gameObject.layer;
            trackedObject.transform.parent = trackedImage.transform;
            trackedObject.transform.rotation = Quaternion.Euler(newRotation);
            referenceTrackObjectCounter = trackedObjectCounter;
        }

        //trackedObject.transform.position = trackedImage.transform.position + new Vector3(0, -1f, 0);

        CanvasDebugger.instance.SetText("All is good ladies and gents");
    }

    void UpdatePosition(ARTrackedImage trackedImage)
    {
        if(trackedObject != null)
        {
            trackedObject.transform.position = trackedImage.transform.position;

        }


    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        
        Debug.Log("Image trackd changed");
        foreach (var trackedImage in eventArgs.added)
        {
            // Give the initial image a reasonable default scale
            //trackedImage.transform.localScale = new Vector3(0.01f, 1f, 0.01f);

            ImageDetected(trackedImage);
            //UpdateInfo(trackedImage);
           
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if(referenceTrackObjectCounter != trackedObjectCounter)
                ImageDetected(trackedImage);

            UpdatePosition(trackedImage);
            //CanvasDebugger.instance.SetText("Image Updated: " + Time.time);
        }

        /*foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
            ImageRemoved(removedImage);
            Debug.LogError("Image Removed" + Time.time);
        }*/
    }

}
