using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchManager : MonoBehaviour {

    //必要な変数
    forAndroidSwipe androidSwipe;
    public Vector3 startPosInCamera = new Vector3();
    public Vector3 nowPosInCamera = new Vector3();
    public Vector3 positionVectorInCamera = new Vector3();
    public Vector3 startPos;
    public Vector3 nowPos;
    public GameObject rotationCenter;
    public GameObject MainCameraCanvas;
    public GameObject MainCamera;
    //AndroidRotation
    public Vector3 nowEularAngle;

    //パラメータ
    public float rotationRatio = 0.002f;
    public float moveRatio = 0.001f;
    //AndroidEnlarge
    public float initCameraDistance = 20f;
    public float enlargeRatio = 1f;


    // Use this for initialization
    void Start () {
        //必要な変数
        rotationCenter = GameObject.Find("MainCameraRotationCenter");
        MainCamera = rotationCenter.transform.Find("Main Camera").gameObject;
        MainCameraCanvas = MainCamera.transform.GetChild(0).gameObject;
        androidSwipe = GetComponent<forAndroidSwipe>();

        //処理開始
        androidSwipe.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        androidSwipe.MyUpdate();
	}
}
