﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitychan_Initializer : MonoBehaviour {
    //必要な変数
    unitychan_CNTRL Unitychan_CNTRL;

    public void MyStart()
    {
        //変数設定
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        Unitychan_CNTRL.unitychan = GameObject.Find("unitychan");
        Unitychan_CNTRL.MainCamera = GameObject.Find("Player/Main Camera");
        Unitychan_CNTRL.unitychanCollider = Unitychan_CNTRL.unitychan.GetComponent<UnitychanCollider>();
        //Animator
        Unitychan_CNTRL.unitychan_Anim = Unitychan_CNTRL.unitychan.GetComponent<Animator>();
        Unitychan_CNTRL.RunStateHash = Animator.StringToHash("Base Layer.Run");
        Unitychan_CNTRL.JumpStateHash = Animator.StringToHash("Base Layer.Jump");
        Unitychan_CNTRL.LangingStateHash = Animator.StringToHash("Base Layer.Landing");
    }
}
