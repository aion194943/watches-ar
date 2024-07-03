using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Serialization;
using UnityEngine.XR.ARSubsystems;
using Unity.XR.CoreUtils;

public class ARItemManager : MonoBehaviour
{

    public ARTrackedImageManager arTrackedManager;
    public XRReferenceImageLibrary referenceImageLibrary;

    public static ARItemManager instance;

    public GameObject trackedObject;


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
       // arTrackedManager.referenceLibrary = referenceImageLibrary;
    }

    public void SetTrackedObject(GameObject obj)
    {
        trackedObject = obj;
        arTrackedManager.trackedImagePrefab = trackedObject;
        arTrackedManager.SetTrackablesActive(false);
        arTrackedManager.SetTrackablesActive(true);
    }
}
