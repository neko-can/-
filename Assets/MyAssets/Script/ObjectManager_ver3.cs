using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PhaseDelegate();
public class ObjectManager_ver3 : MonoBehaviour {

    public static PhaseDelegate phaseDelegate;
    public static SelectObjectPhase SelectObject = new SelectObjectPhase();
    EditMapPhase EditMap = new EditMapPhase();

	// Use this for initialization
	void Start () {
        phaseDelegate = new PhaseDelegate(SelectObject.Main);

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
    public override void MyStart()
    {
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
    public override void MyStart()
    {
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

