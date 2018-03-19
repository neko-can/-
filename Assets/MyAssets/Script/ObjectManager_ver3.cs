using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityHelper;

public delegate void PhaseDelegate();
public class ObjectManager_ver3 : MonoBehaviour {

    public GameObject mapInScene;
    public static GameObject MapInScene;

    public static PhaseDelegate phaseDelegate;
    public static SelectObjectPhase SelectObject = new SelectObjectPhase();
    public static EditMapPhase EditMap = new EditMapPhase();

    public static getChild GetChild = new getChild();

	// Use this for initialization
	void Start () {
        phaseDelegate = new PhaseDelegate(SelectObject.Main);
        MapInScene = mapInScene;

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
    List<GameObject> WallsPrefabs = new List<GameObject>();

    public override void MyStart()
    {
        ObjectManager_ver3.GetChild.getChildObject(GameObject.Find("/Prefabs/Walls").transform, ref WallsPrefabs);
        Debug.Log(WallsPrefabs.Count);
    }

    public override void OnChanged()
    {
    }

    public override void MyUpdate()
    {
        ObjectManager_ver3.phaseDelegate = new PhaseDelegate(ObjectManager_ver3.SelectObject.Main);
    }
}

public class EditMapPhase : PhaseClass
{

    List<Vector3> selectableZonesPos = new List<Vector3>();

    public override void MyStart()
    {
        Debug.Log(ObjectManager_ver3.MapInScene.name);
    }

    public override void OnChanged()
    {
    }

    public override void MyUpdate()
    {
    }
}

public abstract class PhaseClass
{
    public abstract void MyStart();
    public abstract void OnChanged();
    public abstract void MyUpdate();

    protected int phase = 0;
    public void Main()
    {
        switch (phase)
        {
            case 0:
                OnChangedMain();
                break;

            default:
                MyUpdate();
                break;
        }
    }

    void OnChangedMain()
    {
        OnChanged();
        phase++;
    }
}

