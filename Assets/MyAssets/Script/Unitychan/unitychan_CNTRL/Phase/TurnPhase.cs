using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityHelper;

public class TurnPhase : MonoBehaviour {

    /// <summary>
    /// ターンしているときの動作
    /// </summary>

    //必要な変数
    //script
    unitychan_CNTRL Unitychan_CNTRL;
    //variable
    private PhaseClass phaseClass;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        phaseClass = new PhaseClass(new OnChanged(OnChanged), new MyUpdate(MyUpdate));
    }

    public void Main()
    {
        phaseClass.Main();
    }

    void MyUpdate()
    {
    }
    void OnChanged()
    {
        Unitychan_CNTRL.unitychan_Anim.SetTrigger("TurnRight");
        //速度＆向き変更
    }
}
