using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・ターゲットコントローラーにスクリプト付与
    /// </summary>

    //必要な変数
    GameObject targetController;
    GameObject upButton;
    GameObject downButton;
    GameObject leftButton;
    GameObject rightButton;
    int noZone;
    List<Vector3> selectableZonesPos;
    Vector2 noDivision;
    ObjectManager_ver3 objectManager_Ver3;

    public void MyStart()
    {
        //targetController = SelectObjectPhase.targetController;
        objectManager_Ver3 = GetComponent<ObjectManager_ver3>();
        targetController = objectManager_Ver3.targetController;
        upButton = targetController.transform.Find("upButton").gameObject;
        leftButton = targetController.transform.Find("leftButton").gameObject;
        rightButton = targetController.transform.Find("rightButton").gameObject;
        downButton = targetController.transform.Find("downButton").gameObject;
        noZone = objectManager_Ver3.noZone;
        selectableZonesPos = objectManager_Ver3.selectableZonesPos;
        noDivision = EditMapPhase.noDivision;

        ////ボタンに関数付与
        //int i = 0; //これがないとAddListenerされない
        //rightButton.GetComponent<Button>().onClick.AddListener(() => rightOnClick(i));
        //leftButton.GetComponent<Button>().onClick.AddListener(() => leftOnClick(i));
        //upButton.GetComponent<Button>().onClick.AddListener(() => upOnClick(i));
        //downButton.GetComponent<Button>().onClick.AddListener(() => downOnClick(i));
    }

    public void leftOnClick()
    {
        objectManager_Ver3.posIndexStatic = (noZone + objectManager_Ver3.posIndexStatic - 1) % noZone;
        objectManager_Ver3.target.transform.position = selectableZonesPos[objectManager_Ver3.posIndexStatic];
        Debug.Log("left");
    }

    public void rightOnClick()
    {
        objectManager_Ver3.posIndexStatic = (objectManager_Ver3.posIndexStatic + 1) % noZone;
        objectManager_Ver3.target.transform.position = selectableZonesPos[objectManager_Ver3.posIndexStatic];
        Debug.Log("right");
    }

    public void upOnClick()
    {
        objectManager_Ver3.posIndexStatic = (noZone + objectManager_Ver3.posIndexStatic - (int)noDivision.x) % noZone;
        objectManager_Ver3.target.transform.position = selectableZonesPos[objectManager_Ver3.posIndexStatic];
        Debug.Log("up");
    }

    public void downOnClick()
    {
        Debug.Log(objectManager_Ver3.posIndexStatic);
        objectManager_Ver3.posIndexStatic = (objectManager_Ver3.posIndexStatic + (int)noDivision.x) % noZone;
        Debug.Log(objectManager_Ver3.posIndexStatic);
        objectManager_Ver3.target.transform.position = selectableZonesPos[objectManager_Ver3.posIndexStatic];
        Debug.Log("down");
    }
}