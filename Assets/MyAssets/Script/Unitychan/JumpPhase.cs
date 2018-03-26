using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityHelper;

public class JumpPhase : MonoBehaviour {

    unitychan_CNTRL Unitychan_CNTRL;
    PhaseClass phaseClass;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        phaseClass = new PhaseClass(new unityHelper.OnChanged(OnChangedFunc), new unityHelper.MyUpdate(MyUpdate));
    }

    public void MyMain()
    {
        phaseClass.Main();
    }

    //実質CNTRLの条件が満たされた時だけ実行される関数
    void MyUpdate()
    {
        Unitychan_CNTRL.unitychan_Anim.SetTrigger("Jump");
        Unitychan_CNTRL.movePhase = new MovePhase(Unitychan_CNTRL.unitychan_Move.MyUpdate);
    }
    void OnChangedFunc()
    {
    }
}
