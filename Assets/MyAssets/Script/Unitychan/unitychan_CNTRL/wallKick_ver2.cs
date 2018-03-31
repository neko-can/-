using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallKick_ver2 : MonoBehaviour {

    //variable
    Vector3 firstVelocityVector;
    Vector3 maxRayVector;
    GameObject unitychan;
    //parameter
    float judgeTimeNorm = 0.4f;


    void OnChanged()
    {
        maxRayVector = firstVelocityVector * judgeTimeNorm;
        maxRayVector.y += 0.5f * Physics.gravity.y * Mathf.Pow(judgeTimeNorm, 2);
        maxRayVector += unitychan.transform.position;
    }
}
