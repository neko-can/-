using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectPhase : MonoBehaviour {

    //必要な変数
    ObjectManager_ver3 objectManager_Ver3;
    //phase固有
    //targetのController設定
    TargetController targetControllerClass;
    ScrollContent scrollContent;

    public void MyStart()
    {
        //必要な変数
        objectManager_Ver3 = GetComponent<ObjectManager_ver3>();

        //targetのController設定
        targetControllerClass = GetComponent<TargetController>();
        targetControllerClass.MyStart();

        //ボタン自動生成
        scrollContent = GetComponent<ScrollContent>();
        scrollContent.MyStart();
    }

    public void MyUpdate()
    {
        //Panelの切り替え
        objectManager_Ver3.phaseDelegate = new PhaseDelegate(objectManager_Ver3.EditMap.MyUpdate);

    }

}
