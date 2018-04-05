using System;
using System.Collections;
using System.Collections.Generic;
using unityHelper;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class testSaveTime : MonoBehaviour {

    public GameObject PlayerNameTextObj;
    public GameObject ListTextModel;
    public GameObject ViewContent;
    public Color FadeColor;
    public Image FadeImage;
    Vector2 modelPos;
    GameObject listModelClone;
    string cloneText;
    string nameText;
    string defaultName = "名無し";
    //保存する情報
    string PlayerName;
    string PlayerListKey = "PlayerList";
    SaveTime saveTime;
    SavePlayerList savePlayerList;
    //シーン遷移
    MyFade myFade;
    bool IsSaveClick = false;
    bool IsCancelClick = false;
    string titleSceneName = "Title";
    float outTimeElapsed = 0f;
    //parameter
    int MaxListRange = 20;
    float ListInterval = 50f;
    float transitionTime = 1f;

    public void MyStart()
    {
        //PlayerListのロード & 初期設定
        savePlayerList = SaveData.GetClass<SavePlayerList>(PlayerListKey, new SavePlayerList());
        defaultName += savePlayerList.NoPlayer.ToString();
        //UI表示
        ShowData();
        //シーン遷移
        myFade = new MyFade(FadeImage, FadeColor, transitionTime);
    }

    public void MyUpdate()
    {
        myFade.MyFadeIn();
        if(IsSaveClick || IsCancelClick)
        {
            outTimeElapsed += Time.deltaTime;
            myFade.MyFadeOut();
            if(outTimeElapsed > transitionTime)
            {
                SceneManager.LoadScene(titleSceneName);
            }
        }
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
        saveTime = new SaveTime();
        saveTime.PlayerName = PlayerName;
        saveTime.ClearTime = SendData.ClearTime;
        //playerlist
        savePlayerList.NoPlayer++;
        savePlayerList.ListIndex = savePlayerList.NoPlayer % MaxListRange;
        savePlayerList.playerList[savePlayerList.ListIndex] = PlayerName;
        //保存
        SaveData.SetClass<SaveTime>(PlayerName, saveTime);
        SaveData.SetClass<SavePlayerList>(PlayerListKey, savePlayerList);
        //チェック
        SaveTime checkData = SaveData.GetClass<SaveTime>(PlayerName, new SaveTime());
        SavePlayerList checkList = SaveData.GetClass<SavePlayerList>(PlayerListKey, new SavePlayerList());
        Debug.Log(checkData.PlayerName);
        Debug.Log(checkList.ListIndex);

        //シーン遷移
        IsSaveClick = true;
    }


    public void ShowData()
    {
        //Dataの一覧表を作る
        SavePlayerList savePlayerList = SaveData.GetClass<SavePlayerList>(PlayerListKey, new SavePlayerList());
        List<string> PlayerList;
        PlayerList = savePlayerList.playerList;
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
            SaveTime cloneData = SaveData.GetClass<SaveTime>(PlayerList[i], new SaveTime());
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
        IsCancelClick = true;
    }

}

//staticだからシーン遷移しても保持される
public class SaveTime
{
    public string PlayerName = "保存されていない";
    public string StageName = "デバック用";
    public float ClearTime = 0f;
    public int[] SaveDate = new int[] { 0, 0, 0, 0, 0, 0}; //年、月、日、時、分、秒

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
    public int ListIndex;
    public int NoPlayer;
}

public class SendData
{
    public static float ClearTime = 0;
    public static string StageName;

    public static void SetClearTime(SaveTime saveTime)
    {
        saveTime.ClearTime = ClearTime;
    }
}