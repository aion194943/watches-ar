using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class TestARCamera : MonoBehaviour
{
    public ARCameraManager arcamManager;
    public ARSession arSessionManager;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnTestARClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTestARClicked( )
    {
        arSessionManager.Reset();
    }
}
