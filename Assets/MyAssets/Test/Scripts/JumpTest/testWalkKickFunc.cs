using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWalkKickFunc : MonoBehaviour {



}

public class WallKickHelp
{
    //wallkickを補助する関数
    Vector3 FromForwardDirection;
    Quaternion rotateDifference;
    GameObject target;
    Quaternion startQ;
    Vector3 nowRotateEular;

    public WallKickHelp(GameObject targetObj, Vector3 ToForwardDirection)
    {
        target = targetObj;
        FromForwardDirection = target.transform.forward;
        rotateDifference = Quaternion.FromToRotation(FromForwardDirection, ToForwardDirection);
        startQ = target.transform.rotation;
    }

    public void RotateObj(float normTime)
    {
        nowRotateEular = startQ.eulerAngles + rotateDifference.eulerAngles * normTime;
        target.transform.rotation = Quaternion.Euler(nowRotateEular);
    }
}
