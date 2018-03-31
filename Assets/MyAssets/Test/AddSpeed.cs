using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeed : MonoBehaviour {

    //RunningPhase
    //source
    Chara_CNTRL chara_CNTRL;
    //variable
    GameObject character;
    //parameter
    [HideInInspector] public float speed = 5f;

    public void MyStart()
    {
        chara_CNTRL = GetComponent<Chara_CNTRL>();
        character = chara_CNTRL.character;
    }

    public void MyUpdate()
    {
        character.GetComponent<Rigidbody>().velocity = speed * character.transform.forward;
    }
}
