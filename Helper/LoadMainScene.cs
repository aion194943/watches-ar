using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    public float timeToLoad = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadTheScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadTheScene( )
    {
        yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene(1);
    }
}
