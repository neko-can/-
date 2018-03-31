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
    float jumpStartTime;
    float jumpEndTime;
    float rayStopTime = 0.6f;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        unitychan_Anim = Unitychan_CNTRL.unitychan_Anim;
        unitychan = Unitychan_CNTRL.unitychan;
        unitychanRb = unitychan.GetComponent<Rigidbody>();
        unitychanCollider = Unitychan_CNTRL.unitychanCollider;
        jumpStartTime = Unitychan_CNTRL.jumpStartTime;
        jumpEndTime = Unitychan_CNTRL.jumpEndTime;
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
        if (Physics.Raycast(ray, out raycastHit, Vector3.Distance(rayPos, rayStartPos)))
        {
            Unitychan_CNTRL.rayColliderObject = raycastHit.collider.gameObject;
            unitychan_Anim.SetTrigger("Landing");

            //if (0.2f < unitychanAnimTime && unitychanAnimTime < 0.6f)
            //{
            //    unitychan_Anim.SetTrigger("Landing");
            //}
        }
    }

    public void OnChanged()
    {
        //初速度変更
        unitychanRb.velocity = new Vector3(0, unitychanRb.velocity.y);
        //初速度取得
        unitychanVelocity = unitychanRb.velocity;
        unitychanVelocity += unitychan.transform.forward * firstVelocityF + new Vector3(0, firstVelocityY);
        Unitychan_CNTRL.unitychanVelocity = unitychanVelocity;
        //落下時間計算
        jumpTime = Mathf.Abs(2 * unitychanVelocity.y / Physics.gravity.y);
        Unitychan_CNTRL.jumpTime = jumpTime;
        //Ray情報取得
        rayPos = unitychan.transform.position;
        rayPos.x += unitychanVelocity.x * rayStopTime * jumpTime;
        rayPos.z += unitychanVelocity.z * rayStopTime * jumpTime;
        rayPos.y += unitychanVelocity.y * rayStopTime * jumpTime + 0.5f * Physics.gravity.y * Mathf.Pow(rayStopTime * jumpTime, 2);
        //ray視覚化
        rayClone = GameObject.Instantiate(rayObject);
        rayClone.transform.position = rayPos;

        //Hitのために
        rayStartPos = unitychan.transform.position;
        rayDirection = rayPos - rayStartPos;
        ray = new Ray(rayStartPos, rayDirection);

    }

    void unityChanRotation()
    {

    }

    public void OnEnd()
    {
        IsOnJump = true;
    }
}
