using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWallCollider : MonoBehaviour {

    //複数の接触を判定するため。
    GameObject unitychanCNTRLObj;
    testUnitychan_CNTRL unitychan_CNTRL;
    GameObject unitychan;

    private void Awake()
    {
        unitychanCNTRLObj = GameObject.Find("CNTRLs/unitychan_CNTRL");
        unitychan_CNTRL = unitychanCNTRLObj.GetComponent<testUnitychan_CNTRL>();
        unitychan = GameObject.Find("unitychan");
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject == unitychan)
        {
            unitychan_CNTRL.IsWallHit = true;
            unitychan_CNTRL.otherCollider = gameObject;
        }
    }

}
