using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRay : MonoBehaviour {

    Controller_CNTRL controller_CNTRL;
    GameObject MainCamera;
    Ray ray;
    Vector3 rayStartPos;
    Vector3 rayDirection;
    RaycastHit raycastHit;
    GameObject hitObj;
    const string StartButtonName = "StartButton";
    const string ManualButtonName = "ManualButton";
    string ActionButtonName;

    public void MyStart()
    {
        controller_CNTRL = GetComponent<Controller_CNTRL>();
        MainCamera = controller_CNTRL.MainCamera;
    }
    public void MyUpdate()
    {
        rayStartPos = MainCamera.transform.position;
        rayDirection = MainCamera.transform.forward;
        ray = new Ray(rayStartPos, rayDirection);
        if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
        {
            Debug.Log(raycastHit.collider.gameObject);
            hitObj = raycastHit.collider.gameObject;
            PushButton();
        }

        ActionButton();
        TestTrans();
    }

    void PushButton()
    {
        switch (hitObj.name)
        {
            case (StartButtonName):
                if (Input.GetMouseButtonDown(0))
                {
                    ActionButtonName = StartButtonName;
                }
                break;

            case (ManualButtonName):
                if (Input.GetMouseButtonDown(0))
                {
                    ActionButtonName = ManualButtonName;
                }
                break;
        }
    }

    void ActionButton()
    {
        switch (ActionButtonName)
        {
            case (StartButtonName):
                controller_CNTRL.sceneTransition.StartOnClick();
                break;

            case (ManualButtonName):
                controller_CNTRL.sceneTransition.ManualOnClick();
                break;
        }
    }

    void TestTrans()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActionButtonName = StartButtonName;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActionButtonName = ManualButtonName;
        }
    }
}
