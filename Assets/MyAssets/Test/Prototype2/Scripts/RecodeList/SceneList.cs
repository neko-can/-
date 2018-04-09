using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneList : MonoBehaviour {


    public string[] raceScenes;
    public GameObject ListTextModel;
    public GameObject ViewContent;
    SavePlayerList savePlayerList;
    List<string> playerList;
    List<string> addKey;
    List<string> raceList = new List<string>();
    List<List<string>> showText = new List<List<string>>();
    List<List<SaveTime>> allDataList = new List<List<SaveTime>>();
    double hour;
    double minute;
    double second;
    float ListInterval = 50f;

    public void MyStart()
    {
        //基本的な変数用意
        savePlayerList = SaveData.GetClass<SavePlayerList>(DataInfo.PlayerListKey, new SavePlayerList());
        addKey = savePlayerList.addKey;
        playerList = savePlayerList.playerList;
        for (int i=0; i<raceScenes.Length; i++)
        {
            raceList.Add(raceScenes[i]);
            showText.Add(new List<string>());
        }

        GetDataPerScene();
    }

    SaveTime oneData;
    int stageIndex;
    GameObject ListModelClone;
    Vector2 clonePos;
    void GetDataPerScene()
    {
        //リスト生成
        for(int i=0; i<playerList.Count; i++)
        {
            oneData = SaveData.GetClass<SaveTime>(playerList[i] + addKey[i], new SaveTime());
            minute = Math.Floor(oneData.ClearTime / 60);
            hour = Math.Floor(minute / 60);
            second = oneData.ClearTime % 60;

            stageIndex = raceList.IndexOf(oneData.StageName);
            Debug.Log(oneData.StageName);
            if(stageIndex != -1)
            {
                showText[stageIndex].Add(oneData.StageName + " " + hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00") + " " + oneData.PlayerName
    + " " + oneData.SaveDate[0].ToString() + "/" + oneData.SaveDate[1].ToString("00") + "/" + oneData.SaveDate[2].ToString("00") + "/" + oneData.SaveDate[3].ToString("00") + "/" + oneData.SaveDate[4].ToString("00") + "/" + oneData.SaveDate[5].ToString("00"));
            }
        }

        //text生成
        int NoRow = 0;
        for(int i=0; i<showText.Count; i++)
        {
            for(int j=0; j<showText[i].Count; j++)
            {
                NoRow++;
                ListModelClone = GameObject.Instantiate(ListTextModel, ViewContent.transform);
                clonePos = ListModelClone.GetComponent<RectTransform>().anchoredPosition;
                clonePos.y -= ListInterval * NoRow;
                Debug.Log(clonePos);
                ListModelClone.GetComponent<RectTransform>().anchoredPosition = clonePos;
                ListModelClone.GetComponent<Text>().text = showText[i][j];
            }
        }
    }

}
