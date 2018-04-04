using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPushButton : MonoBehaviour {

    int touchCount;
    Scene nowScene; //再読み込み用

    public void MyStart()
    {
        nowScene = SceneManager.GetActiveScene();
    }

    public void MyUpdate()
    {
        touchCount = Input.touchCount;
        if(touchCount == 3 || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nowScene.name);
        }
    }
}
