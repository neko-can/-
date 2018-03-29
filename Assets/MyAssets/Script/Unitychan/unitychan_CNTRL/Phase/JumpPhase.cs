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
    UnitychanCollider unitychanCollider;
    float unitychanAnimTime;
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
        unitychanCollider = Unitychan_CNTRL.unitychanCollider;
    }

    public void MyUpdate()
    {
        //必要な変数
        unitychanAnimTime = Unitychan_CNTRL.unitychanAnimTime;

        //初速付与
        if (IsOnJump && unitychanAnimTime >jumpStartTime)
        {
            unitychanVelocity = unitychanRb.velocity;
            unitychanVelocity += unitychan.transform.forward * firstVelocityF + new Vector3(0, firstVelocityY);
            unitychanRb.velocity = unitychanVelocity;

            //unitychanRb.AddForce(new Vector3(0, 100, 0));
            IsOnJump = false;
        }
        //落下速度上昇
        if (unitychanAnimTime > maxHeightTime)
        {
            unitychanVelocity = unitychanRb.velocity;
            unitychanVelocity.y -= 1.3f;
            unitychanRb.velocity = unitychanVelocity;
        }
        //壁キック遷移判定
        if (unitychanCollider.IsHit)
        {
            if(0.2f < unitychanAnimTime && unitychanAnimTime < 0.6f)
            {
                unitychan_Anim.SetTrigger("Landing");
            }
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
