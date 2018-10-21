/*
 * 所属层级：控制层 
 * 脚本功能：系统设置
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_SystemManager : MonoBehaviour
{

    public GameObject SystemManager;
    public Slider BGMusicSlider;
    public Slider FightMusicSlider;

    void Start()
    {
        AudioClipManager._instance.PlayAudioSourceBGByName("MainSceneBG");
        BGMusicSlider.value = AudioClipManager.AudioClipVolumns;
        FightMusicSlider.value = AudioClipManager.GameSoundVolumns;
    }


    void Update()
    {

    }
    /// <summary>
    /// 响应系统设置按钮的点击
    /// </summary>
    public void SystemBtnClick()
    {
        SystemManager.SetActive(true);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
    /// <summary>
    /// 响应确认设置按钮的点击
    /// </summary>
    public void DetermineBtnClick()
    {
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
        AudioClipManager._instance.SetAudioVolumns(BGMusicSlider.value, FightMusicSlider.value);
        SystemManager.SetActive(false);
    }
    /// <summary>
    /// 响应退出按钮的点击
    /// </summary>
    public void BackBtnClick()
    {
        SystemManager.SetActive(false);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
}
 