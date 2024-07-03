using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 35f * Time.deltaTime, 0f));

        rotAngle += 0.1f * Time.deltaTime;

        if(rotAngle > 359)
        {
            rotAngle = 0;
        }
    }
}
