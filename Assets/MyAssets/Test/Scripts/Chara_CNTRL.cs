using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara_CNTRL : MonoBehaviour {

    //script
    AddSpeed addSpeed;
    //variable
    int phaseNumber;
    public GameObject character;
    //phase
    enum Move {
        Run,
        Jump
    };

	// Use this for initialization
	void Start () {
        addSpeed = GetComponent<AddSpeed>();
        phaseNumber = (int)Move.Run;

        addSpeed.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        switch (phaseNumber) {
            case (int)Move.Run:
                addSpeed.MyUpdate();
                break;
        }
	}
}
