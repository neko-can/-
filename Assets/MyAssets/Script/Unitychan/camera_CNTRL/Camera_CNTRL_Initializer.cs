using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_CNTRL_Initializer : MonoBehaviour {

    Camera_CNTRL camera_CNTRL;

    public void MyStart()
    {
        //target
        camera_CNTRL = GetComponent<Camera_CNTRL>();
        //script
        camera_CNTRL.viewerForRunning = GetComponent<ViewerForRunning>();
        //variable
        camera_CNTRL.unitychan = camera_CNTRL.cntrls.unitychan;
        camera_CNTRL.Player = camera_CNTRL.cntrls.Player;
        camera_CNTRL.MainCamera = camera_CNTRL.cntrls.MainCamera;
    }

}
