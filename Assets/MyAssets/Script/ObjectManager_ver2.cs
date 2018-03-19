using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager_ver2 : MonoBehaviour {

    public GameObject MapInScene;

    Map map;
    selectObjectPhase selectPhase;

	// Use this for initialization
	void Start () {
        map = new Map(MapInScene);
        selectPhase = new selectObjectPhase();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Map
{
    /// <summary>
    /// Map情報を格納するクラス
    /// </summary>

    GameObject map;
    List<GameObject> walls = new List<GameObject>();
    public GameObject floor;

    public Map(GameObject MapInScene)
    {
        map = MapInScene;
        floor = map.transform.Find("Floor").GetChild(0).gameObject;
    }

    void GetMapStructure()
    {

    }
}

public class selectObjectPhase
{
    /// <summary>
    /// フェイズ管理をクラスで行う。
    /// </summary>

    GameObject Prefabs;
    List<GameObject> WallPrefabs = new List<GameObject>();

    public selectObjectPhase()
    {
        getPrefabObjects();
    }

    void getPrefabObjects()
    {
        Prefabs = GameObject.Find("Prefabs");
        getChildObject(Prefabs.transform.Find("Walls"), ref WallPrefabs);
    }

    void getChildObject(Transform parentTransform, ref List<GameObject> container)
    {
        foreach(Transform i in parentTransform)
        {
            Debug.Log(i.name);
            container.Add(i.gameObject);
        }
    }
}

public class editMapPhase
{
    Map map;
    GameObject floor;
    Mesh floorMesh;
    Renderer floorRenderer;
    Vector3 startPos;
    List<Vector3> selectableZonesPos = new List<Vector3>();
    Vector3 floorBoundsSize;
    Vector3 floorCenter;
    GameObject selectableZoneClone;
    Vector2 noDivision;
    int noZone;

    public editMapPhase(Map MapInScene)
    {
        map = MapInScene;
        floor = map.floor;
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
}