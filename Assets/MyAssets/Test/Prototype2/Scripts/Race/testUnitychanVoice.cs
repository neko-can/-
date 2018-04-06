using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testUnitychanVoice : MonoBehaviour {

    testCNTRLs cntrls;

    public AudioClip[] jumpVoice;
    public AudioClip[] OnLoadVoice;
    public AudioClip[] OnGoalVoice;
    public AudioClip[] RestartVoice;
    public AudioClip RunningVoice;

    GameObject unitychan;
    AudioSource unitychanVoice;

    int VoiceIndex = 0;

    public void MyStart()
    {
        //Staticへの変数を渡す
        cntrls = GetComponent<testCNTRLs>();
        unitychan = cntrls.unitychan;
        unitychanVoice = unitychan.GetComponent<AudioSource>();

        UnitychanVoiceStatic.jumpVoice = jumpVoice;
        UnitychanVoiceStatic.OnLoadVoice = OnLoadVoice;
        UnitychanVoiceStatic.OnGoalVoice = OnGoalVoice;
        UnitychanVoiceStatic.RestartVoice = RestartVoice;
        UnitychanVoiceStatic.RunningVoice = RunningVoice;
        UnitychanVoiceStatic.unitychan = unitychan;
        UnitychanVoiceStatic.unitychanVoice = unitychanVoice;
    }

}


public static class UnitychanVoiceStatic
{
    public static AudioClip[] jumpVoice;
    public static AudioClip[] OnLoadVoice;
    public static AudioClip[] OnGoalVoice;
    public static AudioClip[] RestartVoice;
    public static AudioClip RunningVoice;

    public static GameObject unitychan;
    public static AudioSource unitychanVoice;

    static int VoiceIndex = 0;
    
    public static void OnJump()
    {
        VoiceIndex = Random.Range(0, jumpVoice.Length);
        unitychanVoice.clip = jumpVoice[VoiceIndex];
        unitychanVoice.loop = false;
        unitychanVoice.Play();
    }
    public static void OnLoad()
    {
        VoiceIndex = Random.Range(0, jumpVoice.Length);
        unitychanVoice.clip = OnLoadVoice[VoiceIndex];
        unitychanVoice.loop = false;
        unitychanVoice.Play();
    }
    public static void OnGoal()
    {
        VoiceIndex = Random.Range(0, jumpVoice.Length);
        unitychanVoice.clip = OnGoalVoice[VoiceIndex];
        unitychanVoice.loop = false;
        unitychanVoice.Play();
    }
    public static void Restart()
    {
        VoiceIndex = Random.Range(0, jumpVoice.Length);
        unitychanVoice.clip = RestartVoice[VoiceIndex];
        unitychanVoice.loop = false;
        unitychanVoice.Play();
    }
    public static void OnRunning()
    {
        unitychanVoice.clip = RunningVoice;
        unitychanVoice.loop = true;
        unitychanVoice.Play();
    }

}