using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitychan_Initializer : MonoBehaviour {
    //必要な変数
    unitychan_CNTRL Unitychan_CNTRL;

    public void MyStart()
    {
        //変数設定
        //target
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        //souce
        Unitychan_CNTRL.cntrls = transform.parent.gameObject.GetComponent<CNTRLs>();
        //variable
        Unitychan_CNTRL.unitychan = Unitychan_CNTRL.cntrls.unitychan;
        Unitychan_CNTRL.MainCamera = GameObject.Find("Player/Main Camera");
        Unitychan_CNTRL.unitychanRb = Unitychan_CNTRL.unitychan.GetComponent<Rigidbody>();
        //script
        Unitychan_CNTRL.unitychanCollider = Unitychan_CNTRL.unitychan.GetComponent<UnitychanCollider>();
        Unitychan_CNTRL.unitychan_Forward = GetComponent<Unitychan_forward>();
        //Animator
        Unitychan_CNTRL.unitychan_Anim = Unitychan_CNTRL.unitychan.GetComponent<Animator>();
        Unitychan_CNTRL.RunStateHash = Animator.StringToHash("Base Layer.Run");
        Unitychan_CNTRL.JumpStateHash = Animator.StringToHash("Base Layer.Jump");
        Unitychan_CNTRL.LandingStateHash = Animator.StringToHash("Base Layer.Landing");
        Unitychan_CNTRL.WaitStateHash = Animator.StringToHash("Base Layer.Wait");
    }
}
