using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityHelper;

public delegate void PhaseDelegate();
public class ObjectManager_ver3 : MonoBehaviour {

    public GameObject mapInScene;
    public static GameObject MapInScene;

    public static PhaseDelegate phaseDelegate;
    public static SelectObjectPhase SelectObject = new SelectObjectPhase();
    public static EditMapPhase EditMap = new EditMapPhase();

    //helper
    public static getChild GetChild = new getChild();
    public static GameObject ownGameObject;

    //EditMapPhase用変数
    //座標操作
    public static int posIndexStatic = 0;
    public static GameObject target;

	// Use this for initialization
	void Start () {
        phaseDelegate = new PhaseDelegate(SelectObject.Main);
        MapInScene = mapInScene;
        ownGameObject = gameObject;

        SelectObject.MyStart();
        EditMap.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        phaseDelegate();
	}
}

public class SelectObjectPhase : PhaseClass
{

    //ボタン自動生成
    ScrollContent scrollContent;

    public override void MyStart()
    {
        //ボタン自動生成
        scrollContent = ObjectManager_ver3.ownGameObject.GetComponent<ScrollContent>();
        scrollContent.MyStart();
    }

    public override void OnChanged()
    {
        Debug.Log("selectOnChanged");
    }

    public override void MyUpdate()
    {
        ObjectManager_ver3.phaseDelegate = new PhaseDelegate(ObjectManager_ver3.EditMap.Main);

    }

    public void OnClick(int i)
    {
        //cloneTarget = GameObject.Instantiate(wallList[i], WallsParent.transform);
        //cloneTarget.transform.position = selectableZonesPos[posIndex];

        //targetObject = cloneTarget;
        //posIndex = 0;
    }

}

public class EditMapPhase : PhaseClass
{
    List<Vector3> selectableZonesPos = new List<Vector3>();
    Renderer floorRenderer;
    GameObject selectableZone;
    GameObject selectableZoneParent;
    GameObject floorInScene;
    Vector3 startPos;
    Vector3 floorBoundsSize;
    Vector3 floorCenter;
    GameObject selectableZoneClone;
    Vector2 noDivision;
    int noZone;

    GameObject targetController;
    GameObject upButton;
    GameObject downButton;
    GameObject leftButton;
    GameObject rightButton;
    public static GameObject targetObject;
    int posIndex = ObjectManager_ver3.posIndexStatic;

    public override void MyStart()
    {
        selectableZone = GameObject.Find("Prefabs/forEditMap/selectableZone");
        floorInScene = ObjectManager_ver3.MapInScene.transform.Find("Floor").GetChild(0).gameObject;
        selectableZoneParent = GameObject.Find("SelectableZoneParent");

        setSelectableZonesPos();
        makeSelectableZone();
    }

    public override void OnChanged()
    {
        Debug.Log("editOnChanged");
    }

    public override void MyUpdate()
    {
    }

    void setSelectableZonesPos()
    {
        floorRenderer = floorInScene.GetComponent<Renderer>();
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
        for (int i = 0; i < noZone; i++)
        {
            selectableZoneClone = GameObject.Instantiate(selectableZone, selectableZoneParent.transform);
            selectableZoneClone.transform.position = selectableZonesPos[i];
        }
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
}


