using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject startPosText;
    public GameObject nowPosText;

    string startTempText = "Start Position : ";
    string nowTempText = "Now Position : ";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        startPosText.GetComponent<Text>().text = startTempText + touchManager.startPos.ToString();
        nowPosText.GetComponent<Text>().text = nowTempText + touchManager.nowPos.ToString();
	}
}
