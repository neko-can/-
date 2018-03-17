using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour {

    public GameObject WallsParent;

    public List<GameObject> buttonList;
    public List<GameObject> wallList;
    int noObjects;

    GameObject cloneTarget;

    int i;

	// Use this for initialization
	void Start () {

        noObjects = wallList.Count;
        for (i=0; i<noObjects; i++)
        {
            buttonList[i].GetComponent<Button>().onClick.AddListener(OnClick);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        Debug.Log(i);
        cloneTarget = GameObject.Instantiate(wallList[i], WallsParent.transform);
    }

}
