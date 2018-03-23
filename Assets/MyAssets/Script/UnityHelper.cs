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
    public class getChild
    {
        public static void getChildObject(Transform parentTransform, ref List<GameObject> container)
        {
            foreach (Transform i in parentTransform)
            {
                Debug.Log(i.name);
                container.Add(i.gameObject);
            }
        }

    }

    public abstract class PhaseClass : MonoBehaviour
    {
        public abstract void MyStart();
        public abstract void OnChanged();
        public abstract void MyUpdate();

        protected int phase = 0;
        public void Main()
        {
            switch (phase)
            {
                case 0:
                    OnChangedMain();
                    break;

                default:
                    MyUpdate();
                    break;
            }
        }

        void OnChangedMain()
        {
            OnChanged();
            phase++;
        }
    }

}