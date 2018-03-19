using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour {

    public GameObject WallsParent;
    public GameObject floor;
    public GameObject selectableZone;
    public GameObject selectableZoneParent;
    GameObject targetController; //ボタンの親

    //UIで補助
    public List<GameObject> buttonList;
    public List<GameObject> wallList;
    public GameObject editerPanel;
    int noObjects;
    GameObject cloneTarget;

    //オブジェクトで補助
    Mesh floorMesh;
    Renderer floorRenderer;
    Vector3 startPos;
    List<Vector3> selectableZonesPos = new List<Vector3>();
    Vector3 floorBoundsSize;
    Vector3 floorCenter;
    GameObject selectableZoneClone;
    Vector2 noDivision;
    int noZone;

    //ターゲットコントローラー
    GameObject upButton;
    GameObject leftButton;
    GameObject rightButton;
    GameObject downButton;
    GameObject targetObject;
    int posIndex = 0;

	// Use this for initialization
	void Start () {

        setSelectableZonesPos();
        setListButton();
        makeSelectableZone();
        setControllerButton();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void setControllerButton()
    {
        targetController = GameObject.Find("Prefabs/UI/targetControllerCanvas");

        upButton = targetController.transform.Find("upButton").gameObject;
        leftButton = targetController.transform.Find("leftButton").gameObject;
        rightButton = targetController.transform.Find("rightButton").gameObject;
        downButton = targetController.transform.Find("downButton").gameObject;

        rightButton.GetComponent<Button>().onClick.AddListener(rightOnClick);
        leftButton.GetComponent<Button>().onClick.AddListener(leftOnClick);
        upButton.GetComponent<Button>().onClick.AddListener(upOnClick);
        downButton.GetComponent<Button>().onClick.AddListener(downOnClick);

        if (targetObject != null)
        {
            GameObject.Instantiate(targetController, targetObject.transform);
        }
        
    }

    void leftOnClick()
    {
        posIndex = (noZone + posIndex - 1) % noZone;
        targetObject.transform.position = selectableZonesPos[posIndex];
    }

    void rightOnClick()
    {
        posIndex = (posIndex + 1) % noZone;
        targetObject.transform.position = selectableZonesPos[posIndex];
    }

    void upOnClick()
    {
        posIndex = (noZone + posIndex - (int)noDivision.x) % noZone;
        targetObject.transform.position = selectableZonesPos[posIndex];
    }

    void downOnClick()
    {
        posIndex = (posIndex + (int)noDivision.x) % noZone;
        targetObject.transform.position = selectableZonesPos[posIndex];
    }

    void setListButton()
    {
        noObjects = wallList.Count;
        for (int i = 0; i < noObjects; i++)
        {
            int ii = i + 0; //一時変数
            buttonList[i].GetComponent<Button>().onClick.AddListener(() => OnClick(ii));
        }
    }

    public void OnClick(int i)
    {
        cloneTarget = GameObject.Instantiate(wallList[i], WallsParent.transform);
        cloneTarget.transform.position = selectableZonesPos[posIndex];

        targetObject = cloneTarget;
        posIndex = 0;
    }

    void setSelectableZonesPos()
    {
        floorRenderer = floor.GetComponent<Renderer>();
        floorBoundsSize = floorRenderer.bounds.size;
        floorCenter = floorRenderer.bounds.center;

        startPos = new Vector3(-floorBoundsSize.x / 2 + 0.5f, 0, -floorBoundsSize.z / 2 + 0.5f);

        noDivision = new Vector2(floorBoundsSize.x, floorBoundsSize.z);

        noZone = (int)(noDivision.x * noDivision.y);
        for (int i = 0; i < noZone; i++)
        {
            selectableZonesPos.Add(new Vector3(startPos.x + i / (int)noDivision.x, 0, startPos.z + i % (int)noDivision.y));
        }
    }

    void makeSelectableZone()
    {
        for(int i=0; i<noZone; i++)
        {
            selectableZoneClone = GameObject.Instantiate(selectableZone, selectableZoneParent.transform);
            selectableZoneClone.transform.position = selectableZonesPos[i];
        }
    }

    void testBounds()
    {
        floorMesh = floor.GetComponent<MeshFilter>().mesh;
        floorRenderer = floor.GetComponent<Renderer>();

        Debug.Log("vertices : " + floorMesh.vertices[0].ToString());
        Debug.Log("bounds.size : " + floorMesh.bounds.size.ToString());
        Debug.Log("renderer's bounds : " + floorRenderer.bounds.size.ToString());
        Debug.Log("renderer's center : " + floorRenderer.bounds.center.ToString());
    }
}