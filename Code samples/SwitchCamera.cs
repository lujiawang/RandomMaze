using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera MainCamera;
    public Camera firstCamera;
    private bool switchCam;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera.GetComponent<Camera>().enabled = true;
        firstCamera.GetComponent<Camera>().enabled = false;
        switchCam = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            switchCam = !switchCam;

        if (switchCam)
        {
            MainCamera.GetComponent<Camera>().enabled = false;
            firstCamera.GetComponent<Camera>().enabled = true;
        }
        else
        {
            MainCamera.GetComponent<Camera>().enabled = true;
            firstCamera.GetComponent<Camera>().enabled = false;
        }

    }
}
