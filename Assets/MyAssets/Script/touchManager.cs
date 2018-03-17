using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchManager : MonoBehaviour {

    public static Vector2 startPos = new Vector2();
    public static Vector2 nowPos = new Vector2();

    float rotationRatio = 1f;
    public GameObject mainCameraCenter;
    Vector2 moveVector;
    Vector2 moveVectorNorm;
    Vector3 initEularAngle;
    Vector3 nowEularAngle;

    Touch[] touches;
    int touchCount;
    Touch nowTouch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        touchCount = Input.touchCount;
        touches = Input.touches;

        if (Input.touchCount > 0)
        {
            nowTouch = touches[touchCount - 1];

            switch (nowTouch.phase)
            {
                case TouchPhase.Began:
                    startPos = nowTouch.position;

                    initEularAngle = mainCameraCenter.transform.rotation.eulerAngles;

                    break;

                case TouchPhase.Moved:
                    nowPos = nowTouch.position;

                    moveVector = nowPos - startPos;
                    moveVectorNorm = moveVector.normalized;
                    nowEularAngle = new Vector3(initEularAngle.x - moveVectorNorm.y * rotationRatio,
                        initEularAngle.y + moveVectorNorm.x * rotationRatio,
                        initEularAngle.z);
                    mainCameraCenter.transform.rotation = Quaternion.Euler(nowEularAngle);
                    initEularAngle = mainCameraCenter.transform.rotation.eulerAngles;

                    break;
            }
        }
	}
}
