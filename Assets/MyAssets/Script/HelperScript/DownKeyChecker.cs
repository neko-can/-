using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownKeyChecker : MonoBehaviour {

    ///<summary>
    ///機能
    ///・全てのKey情報を判定し、KeyCodeを返す
    ///・switchにつなげる
    /// </summary>

    [HideInInspector] public KeyCode key;

    public KeyCode GetKeyDownCode()
    {
        if (Input.anyKeyDown)
        {
            foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    key = code;
                }
            }
        }

        return key;
    }
}
