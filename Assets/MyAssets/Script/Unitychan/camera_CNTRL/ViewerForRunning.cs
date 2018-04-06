using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerForRunning : MonoBehaviour {

    //source
    Camera_CNTRL camera_CNTRL;
    //variable
    GameObject Player;
    public GameObject TargetObject;
    GameObject MainCamera;
    //parameter
    float distance = 0.8f;

    public void MyStart()
    {
        camera_CNTRL = GetComponent<Camera_CNTRL>();
        Player = camera_CNTRL.Player;
        MainCamera = camera_CNTRL.MainCamera;
    }
    public void MyUpdate()
    {
        Player.transform.position = TargetObject.transform.position - distance * MainCamera.transform.forward;
    }

}
