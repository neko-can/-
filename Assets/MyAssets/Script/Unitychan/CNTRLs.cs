using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNTRLs : MonoBehaviour {

    //コントローラー間で使う変数の設定

    //scriptSet
    CNTRLs_Initializer cntrls_Initializer;
    //variable
    public GameObject unitychan;
    [HideInInspector] public GameObject Player;
    [HideInInspector] public GameObject MainCamera;

    private void Awake()
    {
        cntrls_Initializer = GetComponent<CNTRLs_Initializer>();

        cntrls_Initializer.MyStart();
    }
}
