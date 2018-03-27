using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPhase : MonoBehaviour {

    //ソース
    unitychan_CNTRL Unitychan_CNTRL;
    //必要な変数
    Animator unitychan_Anim;
    GameObject unitychan;
    float upSpeed;
    Rigidbody unitychanRb;
    Vector3 unitychanVelocity;
    bool IsOnJump = true;
    //parameter
    float firstVelocityY = 15f;
    float firstVelocityF = 10f;
    float maxHeight = 6f;
    float maxHeightTime = 0.5f;
    float jumpStartTime = 0.2f;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        unitychan_Anim = Unitychan_CNTRL.unitychan_Anim;
        unitychan = Unitychan_CNTRL.unitychan;
        unitychanRb = unitychan.GetComponent<Rigidbody>();
        upSpeed = maxHeight / maxHeightTime;
    }

    public void MyUpdate()
    {
        //jumpPos = unitychan.transform.position;
        //if (Unitychan_CNTRL.unitychanAnimTime < maxHeightTime){
        //    jumpPos.y += upSpeed * Time.deltaTime;
        //    unitychan.transform.position = jumpPos;
        //}
        //if (maxHeightTime < Unitychan_CNTRL.unitychanAnimTime)
        //{
        //    jumpPos.y -= upSpeed * Time.deltaTime;
        //    unitychan.transform.position = jumpPos;
        //}

        //初速付与
        if (IsOnJump && Unitychan_CNTRL.unitychanAnimTime >jumpStartTime)
        {
            unitychanVelocity = unitychanRb.velocity;
            unitychanVelocity += unitychan.transform.forward * firstVelocityF + new Vector3(0, firstVelocityY);
            unitychanRb.velocity = unitychanVelocity;

            //unitychanRb.AddForce(new Vector3(0, 100, 0));
            IsOnJump = false;
        }
        //落下速度上昇
        if (Unitychan_CNTRL.unitychanAnimTime > maxHeightTime)
        {
            unitychanVelocity = unitychanRb.velocity;
            unitychanVelocity.y -= 1.3f;
            unitychanRb.velocity = unitychanVelocity;
        }
    }
    public void OnChanged()
    {
    }

    public void OnEnd()
    {
        IsOnJump = true;
    }
}
