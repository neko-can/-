using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

namespace unityHelper
{
    public static class GetChild
    {
        public static void getChildrenObject(Transform parentTransform, ref List<GameObject> container)
        {
            foreach (Transform i in parentTransform)
            {
                Debug.Log(i.name);
                container.Add(i.gameObject);
            }
        }

    }

    public static class GetKeyDownCode
    {
        public static KeyCode? key = null;

        public static KeyCode? getKeyDownCode()
        {
            if (Input.anyKeyDown)
            {
                foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(code))
                    {
                        key = code;
                    }
                }
            }
            else
            {
                key = null;
            }

            return key;
        }
    }

    public delegate void OnChanged();
    public delegate void MyUpdate();
    delegate void MainDelegate();
    public class PhaseClass
    {
        OnChanged onChanged;
        MyUpdate myUpdate;
        MainDelegate mainDelegate;

        public PhaseClass(OnChanged onChangedDelegate, MyUpdate myUpdateDelegate)
        {
            onChanged = onChangedDelegate;
            myUpdate = myUpdateDelegate;
            
            mainDelegate = new MainDelegate(OnChangedFunc);
        }

        //外部で実行するもの
        public void Main()
        {
            mainDelegate();
        }

        void OnChangedFunc()
        {
            onChanged();
            mainDelegate = new MainDelegate(myUpdate);
        }
    }

    public class MyFade
    {
        float transTime;
        float outElapsedTime;
        float inElapsedTime;
        float inStopper = 0f;
        float outStopper = 0f;
        bool IsInFadeOut = false;
        Image image;
        Color color;
        public MyFade(Image MyFadeImage, Color MyFadeColor, float transitionTime=1f)
        {
            transTime = transitionTime;
            image = MyFadeImage;
            color = MyFadeColor;
            outElapsedTime = 0f;
            inElapsedTime = transTime;
        }

        public void MyFadeOut()
        {
            if(outStopper < transTime)
            {
                //初期化
                inStopper = 0f;
                inElapsedTime = transTime;
                IsInFadeOut = true;

                outElapsedTime += Time.deltaTime;
                color.a = outElapsedTime / transTime; //script上では0~1で制御
                image.color = color;
            }
            outStopper += Time.deltaTime;
        }

        public void MyFadeIn()
        {
            if (!IsInFadeOut)
            {
                if (inStopper < transTime)
                {
                    //初期化
                    outStopper = 0f;
                    outElapsedTime = 0f;

                    inElapsedTime -= Time.deltaTime;
                    color.a = inElapsedTime / transTime;
                    image.color = color;
                }
                inStopper += Time.deltaTime;
            }
        }
    }

}

namespace AndroidHelper
{
    public delegate void TouchPhaseDelegate();

    public class NowTouch
    {
        //必要な変数
        int touchCount;
        Touch[] touches;
        public Touch nowTouch;
        //指定が必要な変数(継承はできない。MonoBehaviorがあるから)
        public TouchPhaseDelegate beganDelegate;
        public TouchPhaseDelegate moveDelegate;

        public void Main()
        {
            touchCount = Input.touchCount;
            touches = Input.touches;

            if (touchCount > 0)
            {
                nowTouch = touches[touchCount - 1];
                switch (nowTouch.phase)
                {
                    case TouchPhase.Began:
                        beganDelegate();
                        break;

                    case TouchPhase.Moved:
                        moveDelegate();
                        break;
                }
            }
        }
    }
}