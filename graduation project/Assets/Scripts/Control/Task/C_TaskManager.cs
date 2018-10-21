/*
 * 所属层级：控制层
 * 脚本功能：控制任务的加载 副本功能的入口
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_TaskManager : MonoBehaviour
{

    public GameObject TaskPanel;

    void Start()
    {

    }

    void Update()
    {

    }
    /// <summary>
    /// 响应任务按钮的点击
    /// </summary>
    public void TaskBtnClick()
    {
        TaskPanel.SetActive(true);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickA");
    }
    /// <summary>
    /// 响应退出按钮的点击
    /// </summary>
    public void ExitBtnClick()
    {
        TaskPanel.SetActive(false);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickA");
    }
}
