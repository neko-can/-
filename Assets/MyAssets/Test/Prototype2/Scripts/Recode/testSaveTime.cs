using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testSaveTime : MonoBehaviour {

    public GameObject PlayerNameTextObj;
    public GameObject ListTextModel;
    public GameObject ViewContent;
    Vector2 modelPos;
    GameObject listModelClone;
    string cloneText;
    string nameText;
    string defaultName = "名無し";
    //保存する情報
    DateTime nowTime;
    string PlayerName;
    string PlayerListKey = "PlayerList";
    SaveTime saveTime;
    SavePlayerList savePlayerList;
    //parameter
    [HideInInspector] public static int MaxListRange = 60;
    float ListInterval = 50f;

    public void MyStart()
    {
        //PlayerListのロード & 初期設定
        savePlayerList = SaveData.GetClass<SavePlayerList>(PlayerListKey, new SavePlayerList());
        if(savePlayerList.playerList.Count != MaxListRange)
        {
            savePlayerList = new SavePlayerList();
        }
        defaultName += savePlayerList.NoPlayer.ToString();
        //UI表示
        ShowData();
    }

    public void MyUpdate()
    {
    }

    public void SaveOnClick()
    {
        //セット
        nameText = PlayerNameTextObj.GetComponent<Text>().text;
        if(nameText == "")
        {
            Debug.Log("実質的null!");
            PlayerName = defaultName;
        }
        else
        {
            PlayerName = nameText;
        }
        //savetime
        nowTime = DateTime.Now;
        saveTime = new SaveTime();
        saveTime.PlayerName = PlayerName;
        saveTime.ClearTime = SendData.ClearTime;
        saveTime.StageName = SendData.StageName;
        saveTime.SaveDate = new int[] {nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, nowTime.Second };//年、月、日、時、分、秒
        //playerlist
        savePlayerList.ListIndex = savePlayerList.NoPlayer % MaxListRange;
        savePlayerList.NoPlayer++;
        savePlayerList.playerList[savePlayerList.ListIndex] = PlayerName;
        savePlayerList.addKey[savePlayerList.ListIndex] = nowTime.ToString();
        //保存
        SaveData.SetClass<SaveTime>(PlayerName + savePlayerList.addKey[savePlayerList.ListIndex], saveTime);
        SaveData.SetClass<SavePlayerList>(PlayerListKey, savePlayerList);
        SaveData.Save();
        //チェック
        SaveTime checkData = SaveData.GetClass<SaveTime>(PlayerName + savePlayerList.addKey[savePlayerList.ListIndex], new SaveTime());
        SavePlayerList checkList = SaveData.GetClass<SavePlayerList>(PlayerListKey, new SavePlayerList());
        Debug.Log(checkData.PlayerName);
        Debug.Log(checkList.ListIndex);
    }


    public void ShowData()
    {
        //Dataの一覧表を作る
        SavePlayerList savePlayerList = SaveData.GetClass<SavePlayerList>(PlayerListKey, new SavePlayerList());
        List<string> PlayerList;
        List<string> addKey;
        PlayerList = savePlayerList.playerList;
        addKey = savePlayerList.addKey;
        double hour;
        double minute;
        double second;
        for(int i = 0; i<savePlayerList.playerList.Count; i++)
        {
            //本体
            listModelClone = GameObject.Instantiate(ListTextModel, ViewContent.transform);
            modelPos = listModelClone.GetComponent<RectTransform>().anchoredPosition;
            modelPos.y -= ListInterval * (i + 1); //タイトル分
            listModelClone.GetComponent<RectTransform>().anchoredPosition = modelPos;

            //text部分
            SaveTime cloneData = SaveData.GetClass<SaveTime>(PlayerList[i] + addKey[i], new SaveTime());
            minute = Math.Floor(cloneData.ClearTime / 60);
            hour = Math.Floor(minute / 60);
            second = cloneData.ClearTime % 60;
            cloneText = cloneData.StageName + " " + hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00") + " " + cloneData.PlayerName
                + " " + cloneData.SaveDate[0].ToString() + "/" + cloneData.SaveDate[1].ToString("00") + "/" + cloneData.SaveDate[2].ToString("00") + "/" + cloneData.SaveDate[3].ToString("00") + "/" + cloneData.SaveDate[4].ToString("00") + "/" + cloneData.SaveDate[5].ToString("00");
            listModelClone.GetComponent<Text>().text = cloneText;
        }
    }

    public void CancelOnClick()
    {
    }

}

//staticだからシーン遷移しても保持される
public class SaveTime
{
    public string PlayerName = "保存されていない";
    public string StageName = "デバック用";
    public float ClearTime = 9999f;
    public int[] SaveDate = new int[6]; 

    public SaveTime()
    {
        SaveDate[0] = DateTime.Now.Year;
        SaveDate[1] = DateTime.Now.Month;
        SaveDate[2] = DateTime.Now.Day;
        SaveDate[3] = DateTime.Now.Hour;
        SaveDate[4] = DateTime.Now.Minute;
        SaveDate[5] = DateTime.Now.Second;
    }
}

public class SavePlayerList
{
    public List<string> playerList = new List<string>();
    public List<string> addKey = new List<string>();
    public int ListIndex;
    public int NoPlayer;

    public SavePlayerList()
    {
        for (int i=0; i<testSaveTime.MaxListRange; i++)
        {
            playerList.Add("データなし");
            addKey.Add(DateTime.Now.ToString());
        }
    }
}

public class SendData
{
    public static float ClearTime = 9999f;
    public static string StageName = "ステージ名";

    public static void SetClearTime(SaveTime saveTime)
    {
        saveTime.ClearTime = ClearTime;
    }
}