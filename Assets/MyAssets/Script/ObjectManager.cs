using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour {

    public GameObject WallsParent;
    public GameObject floor;

    public List<GameObject> buttonList;
    public List<GameObject> wallList;
    int noObjects;
    GameObject cloneTarget;

    Mesh floorMesh;
    Renderer floorRenderer;

	// Use this for initialization
	void Start () {

        noObjects = wallList.Count;
        for (int i=0; i<noObjects; i++)
        {
            int ii = i + 0; //一時変数
            buttonList[i].GetComponent<Button>().onClick.AddListener(() => OnClick(ii));
        }

        makeSelectableZone();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick(int i)
    {
        cloneTarget = GameObject.Instantiate(wallList[i], WallsParent.transform);
    }

    void makeSelectableZone()
    {
        //floorのサイズは正規化されているものとする。
        floorRenderer = floor.GetComponent<Renderer>();

    }

    void testBounds()
    {
        floorMesh = floor.GetComponent<MeshFilter>().mesh;

        Debug.Log("vertices : " + floorMesh.vertices[0].ToString());
        Debug.Log("bounds.size : " + floorMesh.bounds.size.ToString());
        Debug.Log("renderer's bounds : " + floorRenderer.bounds.size.ToString());
        Debug.Log("renderer's center : " + floorRenderer.bounds.center.ToString());
    }
}
