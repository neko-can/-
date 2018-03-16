using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitychan_CNTRL : MonoBehaviour {

    public GameObject unitychan;

    float baseSpeed = 6f;

    Animator unitychan_Anim;

	// Use this for initialization
	void Start () {
        unitychan_Anim = unitychan.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void LateUpdate()
    {
        unitychan_Anim.SetFloat("Speed", baseSpeed);

    }
}
