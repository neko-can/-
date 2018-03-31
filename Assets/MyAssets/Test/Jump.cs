using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    //variable
    Vector3 firstVelocity;
    Vector3 foward;
    Vector3 rayPos;
    public GameObject rayObject;
    GameObject rayClone;
    public GameObject charaCenter;
    Animator charaAnim;
    Ray ray;
    RaycastHit raycastHit;
    Vector3 rayDirection;
    Vector3 landingDirection;
    //parameter
    Vector2 firstVelocityFU = new Vector2(3, 10);
    float stopTime = 2f;

    private void Start()
    {
        charaAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Animator
            charaAnim.SetTrigger("Jump");
            //Velocity
            foward = gameObject.transform.forward;
            firstVelocity = gameObject.GetComponent<Rigidbody>().velocity;
            firstVelocity.x += foward.x * firstVelocityFU.x;
            firstVelocity.z += foward.z * firstVelocityFU.x;
            firstVelocity.y += firstVelocityFU.y;
            gameObject.GetComponent<Rigidbody>().velocity = firstVelocity;
            //Ray
            MakeRay();
        }
    }

    void MakeRay()
    {
        //firstVelocity決定後に配置
        rayPos = charaCenter.transform.position;
        rayPos += firstVelocity * stopTime + 0.5f * Physics.gravity * Mathf.Pow(stopTime, 2);
        rayClone = GameObject.Instantiate(rayObject);
        rayClone.transform.position = rayPos;

        rayDirection = rayPos - charaCenter.transform.position;
        ray = new Ray(charaCenter.transform.position, rayDirection);
        if(Physics.Raycast(ray, out raycastHit, Vector3.Distance(charaCenter.transform.position, rayPos)))
        {
            Debug.Log("hit");
            landingDirection = raycastHit.collider.gameObject.transform.forward;
        }
    }

    void ForLanding()
    {

    }

}
