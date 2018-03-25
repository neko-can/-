using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPhase : MonoBehaviour {

    /// <summary>
    /// ターンしているときの動作
    /// </summary>

    unitychan_CNTRL Unitychan_CNTRL;

    void MyStart()
    {
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
    }
    void MyUpdate()
    {

    }
    void OnChanged()
    {

    }
}
