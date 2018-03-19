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
        public void getChildObject(Transform parentTransform, ref List<GameObject> container)
        {
            foreach (Transform i in parentTransform)
            {
                Debug.Log(i.name);
                container.Add(i.gameObject);
            }
        }

    }
}