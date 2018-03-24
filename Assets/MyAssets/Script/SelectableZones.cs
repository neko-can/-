using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableZones : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・selectableZone関係
    /// </summary>

    //必要な変数
    Renderer floorRenderer;
    GameObject floorInScene;
    Vector3 floorBoundsSize;
    Vector3 floorCenter;
    Vector3 startPos;
    Vector2 noDivision;
    int noZone;
    List<Vector3> selectableZonesPos = new List<Vector3>();
    GameObject selectableZoneClone;
    GameObject selectableZone;
    GameObject selectableZoneParent;
    ObjectManager_ver3 objectManager_Ver3;


    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void MyStart()
    {
        //必要な変数
        objectManager_Ver3 = GetComponent<ObjectManager_ver3>();
        floorInScene = objectManager_Ver3.MapInScene.transform.Find("Floor").GetChild(0).gameObject;
        selectableZone = GameObject.Find("Prefabs/forEditMap/selectableZone");
        selectableZoneParent = GameObject.Find("SelectableZoneParent");

        setSelectableZonesPos();
        makeSelectableZone();
    }

    void setSelectableZonesPos()
    {
        floorRenderer = floorInScene.GetComponent<Renderer>();
        floorBoundsSize = floorRenderer.bounds.size;
        floorCenter = floorRenderer.bounds.center;

        startPos = new Vector3(-floorBoundsSize.x / 2 + 0.5f, 0.5f, -floorBoundsSize.z / 2 + 0.5f);

        noDivision = new Vector2(floorBoundsSize.x, floorBoundsSize.z);
        EditMapPhase.noDivision = noDivision;

        noZone = (int)(noDivision.x * noDivision.y);
        objectManager_Ver3.noZone = noZone;
        for (int i = 0; i < noZone; i++)
        {
            selectableZonesPos.Add(new Vector3(startPos.x + i / (int)noDivision.x, 0.5f, startPos.z + i % (int)noDivision.y));
        }

        //static化
        objectManager_Ver3.selectableZonesPos = selectableZonesPos;
    }

    void makeSelectableZone()
    {
        for (int i = 0; i < noZone; i++)
        {
            selectableZoneClone = GameObject.Instantiate(selectableZone, selectableZoneParent.transform);
            selectableZoneClone.transform.position = selectableZonesPos[i];
        }
    }


}
