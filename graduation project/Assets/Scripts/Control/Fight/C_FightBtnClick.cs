/*
 * 所属层级：控制层： 
 * 脚本功能：战斗场景的加载
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class C_FightBtnClick : MonoBehaviour
{
    public GameObject FightPanel;
    public Text Timer;
    private int time = 0;
    private bool IsStartTime;

    void Start()
    {
       // InvokeRepeating("TimeCount", 0, 1);
    }

    void Update()
    {
        //    Flo_Time += Time.deltaTime;
        //    Timer.text = Flo_Time.ToString ();
        if (SocketConnect.IsStartFight)
        {
            EnterFight();
            SocketConnect.IsStartFight = false;
        }
        if (IsStartTime)
        {
            Timer.text = "正在匹配:" + time.ToString();
        }
    }
    /// <summary>
    /// 计时器
    /// </summary>
    private void TimeCount()
    {
        time++;
        if (time % 1 == 0)
        {
            //Debug.Log(time);
        }
    }
    /// <summary>
    /// 战斗按钮点击事件
    /// </summary>
    public void FightButtonClick()
    {
        FightPanel.SetActive(true);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
    /// <summary>
    /// 退出按钮点击事件
    /// </summary>
    public void ExitButtonClick()
    {
        FightPanel.SetActive(false);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
    /// <summary>
    /// 开始匹配按钮的点击
    /// </summary>
    public void StartFight()
    {
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickA");
        
        SocketConnect.Instance.SendMessageToServer("请求匹配/" + SocketConnect.PlayerID);
        InvokeRepeating("TimeCount", 0, 1);
        IsStartTime = true;
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
    /// <summary>
    /// 匹配成功后进入游戏
    /// </summary>
    /// <returns></returns>
    public void  EnterFight()
    { 
         Destroy(GameObject.Find("AudioManager"));
         Globe.nextSceneName = "003_Fight";
         SceneManager.LoadScene("Loading");
    }
    

}