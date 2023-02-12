using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControle : MonoBehaviour
{
    public int speedcam = 120;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(0,-speedcam*Time.deltaTime,0);
        }

        if (Input.GetAxis("Mouse X")>0)
        {
            transform.Rotate(0,speedcam*Time.deltaTime,0);
        }
        
    }
}
