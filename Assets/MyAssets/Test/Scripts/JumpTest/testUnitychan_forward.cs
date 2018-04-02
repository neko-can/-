using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testUnitychan_forward : MonoBehaviour {

    //必要な変数
    //script
    testUnitychan_CNTRL Unitychan_CNTRL;
    //variable
    GameObject MainCamera;
    GameObject UnityChan;
    Vector3 CameraForward;
    Vector3 MainCameraFxy;
    Vector3 UnitychanFxy;
    Vector3 UnitychanRotationEular;
    float AngleDifferenceXY;
    //parameters
    float maxTurnAngle = 0f;
    float turnSpeed = 90f;

    public void MyStart()
    {
        //必要な変数
        Unitychan_CNTRL = GetComponent<testUnitychan_CNTRL>();
        MainCamera = Unitychan_CNTRL.MainCamera;
        UnityChan = Unitychan_CNTRL.unitychan;
    }

    public void MyUpdate()
    {
        //必要な変数
        CameraForward = MainCamera.transform.forward;
        UnitychanRotationEular = UnityChan.transform.rotation.eulerAngles;
        MainCameraFxy = new Vector3(CameraForward.x, 0, CameraForward.z);
        UnitychanFxy = new Vector3(UnityChan.transform.forward.x, 0, UnityChan.transform.forward.z);
        AngleDifferenceXY = Vector3.SignedAngle(UnitychanFxy, MainCameraFxy, new Vector3(0, 1, 0));

        //処理
        if (maxTurnAngle < AngleDifferenceXY)
        {
            UnitychanRotationEular.y += turnSpeed * Time.deltaTime;
            UnityChan.transform.rotation = Quaternion.Euler(UnitychanRotationEular);
        }
        else if( AngleDifferenceXY < -maxTurnAngle)
        {
            UnitychanRotationEular.y -= turnSpeed * Time.deltaTime;
            UnityChan.transform.rotation = Quaternion.Euler(UnitychanRotationEular);
        }
        else
        {
            UnityChan.transform.forward = new Vector3(CameraForward.x, 0, CameraForward.z);
        }
    }
}
