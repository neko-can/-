using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityHelper;

public class JumpPhase : MonoBehaviour {

    //ソース
    unitychan_CNTRL Unitychan_CNTRL;
    //必要な変数
    Animator unitychan_Anim;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        unitychan_Anim = Unitychan_CNTRL.unitychan_Anim;
    }

    public void MyMain()
    {
    }

    //実質CNTRLの条件が満たされた時だけ実行される関数
    void MyUpdate()
    {
        unitychan_Anim.SetTrigger("Jump");
        Debug.Log(unitychan_Anim.GetCurrentAnimatorStateInfo(0).ToString());
        Unitychan_CNTRL.movePhase = new MovePhase(Unitychan_CNTRL.unitychan_Move.MyUpdate);
    }
    void OnChangedFunc()
    {
    }
}
