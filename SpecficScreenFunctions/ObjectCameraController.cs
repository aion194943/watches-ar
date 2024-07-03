using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCameraController : MonoBehaviour
{
    public static ObjectCameraController instance;


    public Transform anchorPosition;

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

    public void Spawn3DModelIntoView(GameObject obj)
    {
 
        if(transform.childCount > 1)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
        GameObject newObj = Instantiate(obj, transform, false);
        newObj.transform.position = anchorPosition.position;
        newObj.transform.rotation = anchorPosition.rotation;
        foreach(Transform t in newObj.transform)
        {
            t.gameObject.layer = LayerMask.NameToLayer("ModelPreview");
        }
        newObj.layer = LayerMask.NameToLayer("ModelPreview");

        newObj.AddComponent<RotateObject>();
        
    }
}
