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
        Unitychan_CNTRL.cntrls = transform.parent.gameObject.GetComponent<CNTRLs>();
        //variable
        Unitychan_CNTRL.unitychan = Unitychan_CNTRL.cntrls.unitychan;
        Unitychan_CNTRL.MainCamera = GameObject.Find("Player/Main Camera");
        Unitychan_CNTRL.unitychanRb = Unitychan_CNTRL.unitychan.GetComponent<Rigidbody>();
        //script
        Unitychan_CNTRL.unitychanCollider = Unitychan_CNTRL.unitychan.GetComponent<testUnitychanCollider>();
        Unitychan_CNTRL.unitychan_Forward = GetComponent<testUnitychan_forward>();
        //Animator
        BaseLayerName = Unitychan_CNTRL.BaseLayerName;
        RunName = Unitychan_CNTRL.RunName;
        WaitName = Unitychan_CNTRL.WaitName;
        Unitychan_CNTRL.unitychan_Anim = Unitychan_CNTRL.unitychan.GetComponent<Animator>();
        Unitychan_CNTRL.RunStateHash = Animator.StringToHash(BaseLayerName + "." + RunName);
        Unitychan_CNTRL.WaitStateHash = Animator.StringToHash(BaseLayerName + "." + WaitName);
        //Jump
        ChargeUpName = Unitychan_CNTRL.ChargeUpName;
        LandingName = Unitychan_CNTRL.LandingName;
        ReleaseName = Unitychan_CNTRL.ReleaseName;
        InAirName = Unitychan_CNTRL.InAirName;
        Unitychan_CNTRL.ChargeUpHash = Animator.StringToHash(BaseLayerName + "." + ChargeUpName);
        Unitychan_CNTRL.LandingHash = Animator.StringToHash(BaseLayerName + "." + LandingName);
        Unitychan_CNTRL.ReleaseHash = Animator.StringToHash(BaseLayerName + "." + ReleaseName);
        Unitychan_CNTRL.InAirHash = Animator.StringToHash(BaseLayerName + "." + InAirName);
    }
}
