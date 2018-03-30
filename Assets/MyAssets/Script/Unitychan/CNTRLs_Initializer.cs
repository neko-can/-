using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNTRLs_Initializer : MonoBehaviour {

    //source
    CNTRLs cntrls;

    public void MyStart()
    {
        cntrls = GetComponent<CNTRLs>();
        cntrls.Player = GameObject.Find("Player");
        cntrls.MainCamera = cntrls.Player.transform.Find("Main Camera").gameObject;
    }

}
