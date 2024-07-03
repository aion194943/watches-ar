using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrackerNotification : MonoBehaviour
{

    public static CrackerNotification instance;

    public GameObject crackerTemplate; //fuck toast

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

    public void ShowCrackerMessage(string _message)
    {
        GameObject crackerInstance = Instantiate(crackerTemplate, crackerTemplate.transform.position+new Vector3(0, -4000, 0), Quaternion.identity);
        crackerInstance.gameObject.SetActive(true);
        crackerInstance.transform.parent = crackerTemplate.transform.parent;
        crackerInstance.transform.localScale = Vector3.one;
        crackerInstance.transform.DOMove(crackerTemplate.transform.position, 0.45f);
        crackerInstance.transform.SetAsLastSibling();
        
        crackerInstance.GetComponent<CrackerScript>().ShowMessage(_message);
        StartCoroutine(HideToaster(crackerInstance));
    }

    IEnumerator HideToaster(GameObject objectToTween )
    {
        yield return new WaitForSeconds(3);
        objectToTween.transform.DOMove(crackerTemplate.transform.position + new Vector3(0, -4000, 0), 1.45f).OnComplete(() => KillItWithFire( objectToTween));
    }

    void KillItWithFire(GameObject cracker)
    {
        Destroy(cracker, 1);
    }
}
