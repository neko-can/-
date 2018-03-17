using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour {

    public GameObject WallsParent;

    public List<GameObject> buttonList;
    public List<GameObject> wallList;
    int noObjects;

    GameObject targetObject;
    GameObject cloneTarget;

    OnClickClass onClickClass;

	// Use this for initialization
	void Start () {

        noObjects = wallList.Count;
        for (int i=0; i<noObjects; i++)
        {
            targetObject = wallList[i];

            onClickClass = new OnClickClass(wallList[i], WallsParent);
            buttonList[i].GetComponent<Button>().onClick.AddListener(OnClickClass.OnClick);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}

public class OnClickClass : MonoBehaviour
{
    GameObject targetObject;
    GameObject cloneTarget;
    GameObject WallsParent;

    public OnClickClass(GameObject targetObj, GameObject wallParent)
    {
        targetObject = targetObj;
        WallsParent = wallParent;
    }

    public static void OnClick()
    {
        cloneTarget = GameObject.Instantiate(targetObject, WallsParent.transform);
    }
}
