using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testUnitychan_Initializer : MonoBehaviour {
    //必要な変数
    testUnitychan_CNTRL Unitychan_CNTRL;
    string BaseLayerName;
    string RunName;
    string WaitName;
    string ChargeUpName;
    string LandingName;
    string ReleaseName;
    string InAirName;

    public void MyStart()
    {
        //変数設定
        //target
        Unitychan_CNTRL = GetComponent<testUnitychan_CNTRL>();
        //souce
        Unitychan_CNTRL.cntrls = transform.parent.gameObject.GetComponent<testCNTRLs>();
        //variable
        Unitychan_CNTRL.unitychan = Unitychan_CNTRL.cntrls.unitychan;
        Unitychan_CNTRL.MainCamera = GameObject.Find("Player/Main Camera");
        Unitychan_CNTRL.unitychanRb = Unitychan_CNTRL.unitychan.GetComponent<Rigidbody>();
        //script
        Unitychan_CNTRL.unitychanCollider = Unitychan_CNTRL.unitychan.GetComponent<testUnitychanCollider>();
        Unitychan_CNTRL.unitychan_Forward = GetComponent<testUnitychan_forward>();
        //Animator
        BaseLayerName = Unitychan_CNTRL.cntrls.BaseLayerName;
        RunName = Unitychan_CNTRL.cntrls.RunName;
        WaitName = Unitychan_CNTRL.cntrls.WaitName;
        Unitychan_CNTRL.unitychan_Anim = Unitychan_CNTRL.unitychan.GetComponent<Animator>();
        Unitychan_CNTRL.RunStateHash = Unitychan_CNTRL.cntrls.RunStateHash;
        Unitychan_CNTRL.WaitStateHash = Unitychan_CNTRL.cntrls.WaitStateHash;
        //Jump
        ChargeUpName = Unitychan_CNTRL.cntrls.ChargeUpName;
        LandingName = Unitychan_CNTRL.cntrls.LandingName;
        ReleaseName = Unitychan_CNTRL.cntrls.ReleaseName;
        InAirName = Unitychan_CNTRL.cntrls.InAirName;
        Unitychan_CNTRL.ChargeUpHash = Unitychan_CNTRL.cntrls.ChargeUpHash;
        Unitychan_CNTRL.LandingHash = Unitychan_CNTRL.cntrls.LandingHash;
        Unitychan_CNTRL.ReleaseHash = Unitychan_CNTRL.cntrls.ReleaseHash;
        Unitychan_CNTRL.InAirHash = Unitychan_CNTRL.cntrls.InAirHash;
    }
}
