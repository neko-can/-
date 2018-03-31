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
    Ray ray;
    RaycastHit raycastHit;
    Vector3 rayStartPos;
    Vector3 rayDirection;
    Vector3 rayPos;
    float jumpTime;
    public GameObject rayObject;
    GameObject rayClone;
    //parameter
    float firstVelocityY = 11f;
    float firstVelocityF = 5f;
    //float maxHeightTime = 0.5f;
    float jumpStartTime = 0.2f;
    float rayStopTime = 0.4f;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        unitychan_Anim = Unitychan_CNTRL.unitychan_Anim;
        unitychan = Unitychan_CNTRL.unitychan;
        unitychanRb = unitychan.GetComponent<Rigidbody>();
        unitychanCollider = Unitychan_CNTRL.unitychanCollider;
    }

    public void MyUpdate()
    {
        //必要な変数
        unitychanAnimTime = Unitychan_CNTRL.unitychanAnimTime;

        //初速付与
        if (IsOnJump && unitychanAnimTime >jumpStartTime)
        {
            unitychanRb.velocity = unitychanVelocity;

            //unitychanRb.AddForce(new Vector3(0, 100, 0));
            IsOnJump = false;
        }
        //落下速度上昇
        //if (unitychanAnimTime > maxHeightTime)
        //{
        //    unitychanVelocity = unitychanRb.velocity;
        //    unitychanVelocity.y -= 1.3f;
        //    unitychanRb.velocity = unitychanVelocity;
        //}
        //壁キック遷移判定
        //if (unitychanCollider.IsHit)
        //{
        //    if (0.2f < unitychanAnimTime && unitychanAnimTime < 0.6f)
        //    {
        //        unitychan_Anim.SetTrigger("Landing");
        //    }
        //}
    }

    void JudgeToSecondJump()
    {
        //firstVelocity設定後にRayを飛ばし、当たったら遷移
        rayStartPos = unitychan.transform.position;
        rayDirection = unitychan.transform.forward;
        ray = new Ray(rayStartPos, rayDirection);
    }

    public void OnChanged()
    {
        //初速度変更
        //初速度取得
        unitychanVelocity = unitychanRb.velocity;
        unitychanVelocity += unitychan.transform.forward * firstVelocityF + new Vector3(0, firstVelocityY);

        //落下時間計算
        jumpTime = Mathf.Abs(2 * unitychanVelocity.y / Physics.gravity.y);
        Debug.Log(jumpTime);
        //Ray情報取得
        rayPos = unitychan.transform.position;
        rayPos.x += unitychanVelocity.x * rayStopTime * jumpTime;
        rayPos.z += unitychanVelocity.z * rayStopTime * jumpTime;
        rayPos.y += unitychanVelocity.y * rayStopTime * jumpTime + 0.5f * Physics.gravity.y * Mathf.Pow(rayStopTime * jumpTime, 2);
        //ray視覚化
        rayClone = GameObject.Instantiate(rayObject);
        rayClone.transform.position = rayPos;
    }

    public void OnEnd()
    {
        IsOnJump = true;
    }
}
