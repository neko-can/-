using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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