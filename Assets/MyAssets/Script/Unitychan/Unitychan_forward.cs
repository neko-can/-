using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unitychan_forward : MonoBehaviour {

    //必要な変数
    //script
    unitychan_CNTRL Unitychan_CNTRL;
    //variable
    GameObject MainCamera;
    GameObject UnityChan;
    Vector3 CameraForward;

    public void MyStart()
    {
        //必要な変数
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        MainCamera = Unitychan_CNTRL.MainCamera;
        UnityChan = Unitychan_CNTRL.unitychan;
    }

    public void MyUpdate()
    {
        CameraForward = MainCamera.transform.forward;
        UnityChan.transform.forward = new Vector3(CameraForward.x, 0, CameraForward.z);
    }
}
