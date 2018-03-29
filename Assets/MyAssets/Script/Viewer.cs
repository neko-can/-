using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Viewer : MonoBehaviour
{

    /// <summary>
    /// 機能
    /// ・常に視界の中央にObjectを捉え、頭の回転でObjectを全方向から眺められるようにする。
    /// ・外部のObjectに付与
    /// →Main CameraのCenterOfMassを変更すればいい。→効果なし
    /// →カメラのforwardを基に計算
    /// </summary>

    public GameObject VRCamera;
    public GameObject targetObject;
    public GameObject CameraPositionText;

    public float distance;

    Text PositionText;

    // Use this for initialization
    void Start()
    {
        if(CameraPositionText != null)
        {
            PositionText = CameraPositionText.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        VRCamera.transform.position = targetObject.transform.position - distance * VRCamera.transform.forward;

        if (CameraPositionText != null)
        {
            PositionText.text = "Main Camera's position : " + VRCamera.transform.position.ToString();
        }
    }
}
