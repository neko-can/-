using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MovePhase();
public class unitychan_CNTRL : MonoBehaviour {

    //必要な変数
    //script
    unitychan_Initializer Unitychan_Initializer;
    public Unitychan_forward unitychan_Forward;
    public Unitychan_Move unitychan_Move;
    //variable
    public GameObject unitychan;
    public Animator unitychan_Anim;
    public GameObject MainCamera;
    public MovePhase movePhase;

    //parameters
    public float runningSpeed = 6f;

	// Use this for initialization
	void Start () {
        MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        MyUpdate();
	}

    private void LateUpdate()
    {
        MyLaterUpdate();
    }

    void MyStart()
    {
        //必要な変数
        Unitychan_Initializer = GetComponent<unitychan_Initializer>();
        unitychan_Forward = GetComponent<Unitychan_forward>();
        unitychan_Move = GetComponent<Unitychan_Move>();

        Unitychan_Initializer.MyStart();
        unitychan_Forward.MyStart();
        unitychan_Move.MyStart();
    }

    void MyUpdate()
    {
        movePhase();
    }

    void MyLaterUpdate()
    {
        unitychan_Move.MyLaterUpdate();
    }
}
