using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMap : MonoBehaviour {

    //必要な変数
    ObjectManager_ver3 objectManager_Ver3;
    GameObject MapInScene;
    string key;
    string InputString;
    //外部指定
    public GameObject InputText;
    //保存用
    Map map = new Map();

    public void MyStart()
    {
        objectManager_Ver3 = GetComponent<ObjectManager_ver3>();
        MapInScene = objectManager_Ver3.MapInScene;
    }

    public void SaveOnClick()
    {
        InputString = InputText.GetComponent<Text>().text;
        if(InputString != "")
        {
            key = InputString;
            map.MapInScene = MapInScene;
            SaveData.SetClass<Map>(key, map);
            SaveData.Save();
        }
    }

    public void LoadOnClick()
    {
        string loadKey = "testMap";
        Map loadMap;

        loadMap = SaveData.GetClass<Map>(loadKey, new Map());
        Debug.Log(loadMap.MapInScene);
    }

    public class Map
    {
        public GameObject MapInScene;

        public Map()
        {

        }
    }

}
