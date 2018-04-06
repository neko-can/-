using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCNTRLs : MonoBehaviour {

    //コントローラー間で使う変数の設定

    //scriptSet
    testCNTRLs_Initializer cntrls_Initializer;
    //script
    [HideInInspector] public testUnitychanVoice unitychanVoice;
    //variable
    public GameObject unitychan;
    [HideInInspector] public GameObject Player;
    [HideInInspector] public GameObject MainCamera;
    //Animator
    [HideInInspector] public Animator unitychan_Anim;
    [HideInInspector] public int unitychanAnimHash;
    [HideInInspector] public string BaseLayerName = "Base Layer";
    [HideInInspector] public string RunName = "Run";
    [HideInInspector] public string WaitName = "Wait";
    [HideInInspector] public string ChargeUpName = "ChargeUp";
    [HideInInspector] public string LandingName = "Landing";
    [HideInInspector] public string ReleaseName = "Release";
    [HideInInspector] public string InAirName = "InAir";
    [HideInInspector] public int RunStateHash;
    [HideInInspector] public int WaitStateHash;
    [HideInInspector] public int ChargeUpHash;
    [HideInInspector] public int LandingHash;
    [HideInInspector] public int ReleaseHash;
    [HideInInspector] public int InAirHash;

    private void Awake()
    {
        cntrls_Initializer = GetComponent<testCNTRLs_Initializer>();

        cntrls_Initializer.MyStart();
    }
}
