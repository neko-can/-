using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkTouch : MonoBehaviour {

    public unitychan_CNTRL Unitychan_CNTRL;
    Text touchCountText;

	// Use this for initialization
	void Start () {
        touchCountText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        touchCountText.text = "touchCount = " + Unitychan_CNTRL.touchCount.ToString() + " 回";
	}
}
