using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingPrefabUpdater : MonoBehaviour
{
    public static TrackingPrefabUpdater instance;

    public GameObject activeObject;
    public GameObject referencedObject;
    public GameObject arImageGameObject;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(CanvasDebugger.instance != null)
        {
            CanvasDebugger.instance.SetText("Tracking Prefab Updater exists and working");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetReferenceObject(GameObject referenceObj)
    {
        referencedObject = referenceObj;
        CanvasDebugger.instance.SetText("Refenrece object added: " + referenceObj.name);

    }

    public GameObject SpawnNewObject( )
    {
        //CanvasDebugger.instance.SetText("SpawnNewObject New Object: " + referencedObject.name);
        if (arImageGameObject != null)
        {
            if (activeObject != null && referencedObject != null)
            {
                if (activeObject.name != referencedObject.name)
                {
                    CanvasDebugger.instance.SetText("Different Active Object! | Destroy old one");
                    Destroy(activeObject);
                }
            }
            else
            {
                if(activeObject == null)
                {
                    CanvasDebugger.instance.SetText("TrackingPrefabUpdate::::: Active object is null ");
                }

                if(referencedObject == null)
                {
                    CanvasDebugger.instance.SetText("TrackingPrefabUpdate::::: Reference object is null ");
                }
               
            }

            activeObject = Instantiate(referencedObject, arImageGameObject.transform.position, Quaternion.identity);
            //activeObject.transform.parent = transform;
            
            CanvasDebugger.instance.SetText("{CIP}: Spawn New Object added: " + activeObject.name);
            return activeObject;
        }
        else
        {
            CanvasDebugger.instance.SetText("Ar Image Game Object is null");

        }

        return null;

    }
}
