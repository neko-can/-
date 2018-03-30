using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewer_ver2 : MonoBehaviour {

    ///<summary>
    ///機能
    ///・PlayerのPositionとRotationしか変更できない
    /// </summary>

    //必要な変数
    public GameObject CameraParent;
    public GameObject targetObject;
    GameObject VRCamera;
    //paremeter
    float distance = 3f;

    private void Start()
    {
        VRCamera = CameraParent.transform.Find("Main Camera").gameObject;
    }

    private void Update()
    {
        CameraParent.transform.position = targetObject.transform.position - distance * VRCamera.transform.forward;
    }
}
