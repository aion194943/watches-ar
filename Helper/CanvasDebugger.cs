using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasDebugger : MonoBehaviour
{
    public static CanvasDebugger instance;
    TextMeshProUGUI debuggerText;

    public List<string> debugTextLines;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        debugTextLines = new List<string>();
        debuggerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.SetAsLastSibling();
    }

    public void SetText(string text)
    {
        /*debugTextLines.Clear();
        if (debugTextLines.Count > 20)
        {
            
            debuggerText.text = "";
        }

        debugTextLines.Add(text);
        foreach(string str in debugTextLines)
        {
            debuggerText.text = debuggerText.text + "\n" + str;
        }*/



    }
}
