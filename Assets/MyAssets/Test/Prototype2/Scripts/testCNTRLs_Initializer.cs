using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCNTRLs_Initializer : MonoBehaviour {

    //source
    testCNTRLs cntrls;
    //Animator
    string BaseLayerName;
    string RunName;
    string WaitName;
    string ChargeUpName;
    string LandingName;
    string ReleaseName;
    string InAirName;

    public void MyStart()
    {
        cntrls = GetComponent<testCNTRLs>();
        cntrls.Player = GameObject.Find("Player");
        cntrls.MainCamera = cntrls.Player.transform.Find("Main Camera").gameObject;
        //Animator
        BaseLayerName = cntrls.BaseLayerName;
        RunName = cntrls.RunName;
        WaitName = cntrls.WaitName;
        cntrls.unitychan_Anim = cntrls.unitychan.GetComponent<Animator>();
        cntrls.RunStateHash = Animator.StringToHash(BaseLayerName + "." + RunName);
        cntrls.WaitStateHash = Animator.StringToHash(BaseLayerName + "." + WaitName);
        ChargeUpName = cntrls.ChargeUpName;
        LandingName = cntrls.LandingName;
        ReleaseName = cntrls.ReleaseName;
        InAirName = cntrls.InAirName;
        cntrls.ChargeUpHash = Animator.StringToHash(BaseLayerName + "." + ChargeUpName);
        cntrls.LandingHash = Animator.StringToHash(BaseLayerName + "." + LandingName);
        cntrls.ReleaseHash = Animator.StringToHash(BaseLayerName + "." + ReleaseName);
        cntrls.InAirHash = Animator.StringToHash(BaseLayerName + "." + InAirName);
    }

}
