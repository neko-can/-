using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AndroidHelper;

public class forAndroidSwipe : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・touchManagerで制御
    /// </summary>

    //必要な変数
    touchManager TouchManager;
    NowTouch AndroidMove = new NowTouch();
    NowTouch AndroidRotation = new NowTouch();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MyStart()
    {
        //変数用意
        TouchManager = GetComponent<touchManager>();
        AndroidMove.beganDelegate = new TouchPhaseDelegate(MoveBegan);
        AndroidMove.moveDelegate = new TouchPhaseDelegate(MoveMove);
        AndroidRotation.beganDelegate = new TouchPhaseDelegate(RotationBegan);
        AndroidRotation.moveDelegate = new TouchPhaseDelegate(RotationMove);
    }

    public void MyUpdate()
    {
        AndroidMove.Main();
        AndroidRotation.Main();
    }

    //AndroidMove
    void MoveBegan()
    {
    }
    void MoveMove()
    {
    }

    //AndroidRotation
    void RotationBegan()
    {
        //変数用意
        TouchManager.startPosInCamera = AndroidRotation.nowTouch.position;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(TouchManager.MainCameraCanvas.GetComponent<RectTransform>(), TouchManager.startPosInCamera, TouchManager.MainCamera.GetComponent<Camera>(), out TouchManager.startPos);

    }
    void RotationMove()
    {
        //変数用意
        TouchManager.nowPosInCamera = AndroidRotation.nowTouch.position;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(TouchManager.MainCameraCanvas.GetComponent<RectTransform>(), TouchManager.nowPosInCamera, TouchManager.MainCamera.GetComponent<Camera>(), out TouchManager.nowPos);

        //処理
        TouchManager.positionVectorInCamera = TouchManager.startPosInCamera - TouchManager.nowPosInCamera;
        TouchManager.nowEularAngle = TouchManager.rotationCenter.transform.rotation.eulerAngles + TouchManager.rotationRatio * new Vector3(0, -TouchManager.positionVectorInCamera.x, TouchManager.positionVectorInCamera.y);
        TouchManager.rotationCenter.transform.rotation = Quaternion.Euler(TouchManager.nowEularAngle);

    }
}
