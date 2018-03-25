using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityHelper;

public delegate void myDelegate();
public class forPCSwipe : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・PCでスマホでビルドせずテストできるようにする
    /// ・Alt＋中クリック長押しで移動
    /// ・Alt+左クリック長押しで回転
    /// ・ホイールで拡大縮小
    /// ・touchManagerに付与
    /// </summary>

    //必要な変数
    Vector3 startPosInCamera = new Vector3();
    Vector3 nowPosInCamera = new Vector3();
    Vector3 positionVectorInCamera = new Vector3();
    Vector3 startPos;
    Vector3 nowPos;
    public static GameObject rotationCenter;
    GameObject MainCameraCanvas;
    public static GameObject MainCamera;
    public static myDelegate phaseDelegate;
    //PCRotation
    Vector3 nowEularAngle;
    //PCEnlarge
    PCEnlargeClass pcEnlargeClass = new PCEnlargeClass();

    //パラメータ
    float rotationRatio = 0.002f;
    float moveRatio = 0.001f;
    //PCEnlarge
    public static float initCameraDistance = 20f;
    public static float enlargeRatio = 1f;

	// Use this for initialization
	void Start () {
        //必要な変数
        rotationCenter = GameObject.Find("MainCameraRotationCenter");
        MainCamera = rotationCenter.transform.Find("Main Camera").gameObject;
        MainCameraCanvas = MainCamera.transform.GetChild(0).gameObject;
        pcEnlargeClass.MyStart();
	}
	
	// Update is called once per frame
	void Update () {

        //PCEnlarge
        pcEnlargeClass.Main();

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {

            //PCMove
            if (Input.GetMouseButtonDown(2))
            {
                startPosInCamera = Input.mousePosition;
                RectTransformUtility.ScreenPointToWorldPointInRectangle(MainCameraCanvas.GetComponent<RectTransform>(), startPosInCamera, MainCamera.GetComponent<Camera>(), out startPos);
            }


            if (Input.GetMouseButton(2))
            {
                nowPosInCamera = Input.mousePosition;
                RectTransformUtility.ScreenPointToWorldPointInRectangle(MainCameraCanvas.GetComponent<RectTransform>(), nowPosInCamera, MainCamera.GetComponent<Camera>(), out nowPos);

                PCMove();
            }

            //PCRotation
            if (Input.GetMouseButtonDown(0))
            {
                startPosInCamera = Input.mousePosition;
            }
            if (Input.GetMouseButton(0)){
                nowPosInCamera = Input.mousePosition;
                PCRotation();
            }

        }

    }

    void PCMove()
    {
        //rotation centerを移動できれば良い
        rotationCenter.transform.position = (rotationCenter.transform.position + moveRatio * (startPos - nowPos));
    }

    void PCRotation()
    {
        positionVectorInCamera = startPosInCamera - nowPosInCamera;
        nowEularAngle = rotationCenter.transform.rotation.eulerAngles + rotationRatio * new Vector3(0, -positionVectorInCamera.x, positionVectorInCamera.y);
        rotationCenter.transform.rotation = Quaternion.Euler(nowEularAngle);
        Debug.Log(nowPos);
    }

}

public class PCEnlargeClass
{
    //必要な変数
    PhaseClass phaseClass;
    Vector3 initDistanceVector = new Vector3();
    Vector3 nowDistanceVector = new Vector3();
    float initCameraDistance;

    public void MyStart()
    {
        phaseClass = new PhaseClass(new OnChanged(OnChanged), new MyUpdate(MyUpdate));

        initCameraDistance = forPCSwipe.initCameraDistance;
        changeDistance(initCameraDistance);
    }

    public void Main()
    {
        phaseClass.Main();
    }

    public void MyUpdate()
    {
        if(Input.GetAxis("Mouse ScrollWheel") == 0f) //変数初期化
        {
            initDistanceVector = forPCSwipe.rotationCenter.transform.position - forPCSwipe.MainCamera.transform.position;
            nowDistanceVector = initDistanceVector;
        }
        else
        {
            initCameraDistance += forPCSwipe.enlargeRatio * Input.GetAxis("Mouse ScrollWheel");
            changeDistance(initCameraDistance);
        }
    }

    public void OnChanged()
    {
    }

    void changeDistance(float distance)
    {
        forPCSwipe.MainCamera.transform.position = forPCSwipe.rotationCenter.transform.position + (forPCSwipe.MainCamera.transform.position - forPCSwipe.rotationCenter.transform.position).normalized * distance;
    }
}
