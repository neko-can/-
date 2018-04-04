using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFloorCollider : MonoBehaviour {

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
            Debug.Log("check");
            unitychan_CNTRL.IsFloorHit = true;
            unitychan_CNTRL.otherCollider = gameObject;
        }
    }
}
