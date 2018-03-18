using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager_ver2 : MonoBehaviour {

    public GameObject Map;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

class selectClonePhase : ObjectManager_ver2
{
    GameObject Floor;
    Renderer floorRenderer;
    Vector3 floorCenter;
    Vector3 floorBoundsSize;

    selectClonePhase()
    {
        Floor = Map.transform.Find("Floor").transform.gameObject;

        floorRenderer = Floor.GetComponent<Renderer>();
        floorBoundsSize = floorRenderer.bounds.size;
        floorCenter = floorRenderer.bounds.center;
    }

}

class editCoursePhase : MonoBehaviour
{
    ///<summary>
    ///機能
    ///・selectablezone作成（コンストラクタ活用）
    ///・
    /// </summary>
}