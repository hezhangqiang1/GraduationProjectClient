/* 
 * 所属层级：控制层
 * 脚本功能：控制开始菜单登录注册等界面的转换
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class C_StartMenu : MonoBehaviour {

    public static string PlayerName="";                              //用户名
    public static string Password="";                                //密码

    public Image BGImage;
    public GameObject LoginbanPanel;                                 //登录面板 
    public GameObject RegisterbanPanel;                              //注册面板
    public GameObject MainPanel;                                     //开始界面
    public RectTransform MessagePanel;                               //提示信息面板
    public RectTransform RegisterPanel;                              //注册面板的UI坐标
    public InputField LoginPlayerNameIF;                             //登录用户名输入
    public InputField LoginPasswordIF;                               //登录密码输入
    public InputField RegisterPlayerNameIF;                          //注册用户名输入
    public InputField RegisterPasswordIF;                            //注册密码输入
    public InputField CFRegisterPasswordIF;                          //确认密码输入
    public Text Message;                                             //提示信息
    //public static C_StartMenu Instance;                             //本类实例

    private float FloWaitTime = 0.5f;                                //显示和隐藏面板的协程等待时间
    private float HideTime = 1f;                                     //隐藏时间
    private bool IsHide = false;

    private  GameObject AudioSourceBG;
    
    void Start()
    {
        //MessagePanel = MessagePanel.GetComponent<RectTransform>();
        RegisterbanPanel.transform.DOScale(0, 1);
        AudioClipManager._instance.PlayAudioSourceBGByName("WaterSound");
        AudioSourceBG = GameObject.Find("AudioSourceBG");
    }
    void Update()
    {
        if (IsHide)
        {
            HideTime -= Time.deltaTime;
            if(HideTime <= 0)
            {
                MessagePanel.DOLocalMoveY(1000f, 0.5f);
                Message.text = "";
                HideTime = 1;
                IsHide = false;
            }
        }
    }
    /// <summary>
    /// 响应登录按钮的点击
    /// </summary>
    public void LoginBtnClick()
    {
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickA");
        //TODO 查询数据库 登录之后一系列初始化操作
        SocketConnect.Instance.SendMessageToServer("请求登录/"+ LoginPlayerNameIF.text+"/"+LoginPasswordIF.text);
        StartCoroutine(Login());
        
    }
    /// <summary>
    /// 判断登录的协程
    /// 解决服务器Reply的延迟问题
    /// </summary>
    /// <returns></returns>
    IEnumerator Login()
    {
        yield return new WaitForSeconds(0.5f);
        if (SocketConnect.IsLogin)
        {
            PlayerName = LoginPlayerNameIF.text;
            Globe.nextSceneName = "002_NewVillage";
            SceneManager.LoadScene("Loading");
        }
        else if(SocketConnect.IsOnline)
        {
            PromptMessage("当前用户在线");
        }
        else
        {
            PromptMessage("用户名或密码错误");
        }
       
    }
   
   /// <summary>
   /// 响应前往注册按钮的点击
   /// </summary>
    public void RegisterBtnClick()
    {
        AudioClipManager._instance.StopPlayBGSound();
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickA");
        //Debug.Log(" 响应前往注册按钮");
        // StartCoroutine(HidePanel(LoginbanPanel));
        // StartCoroutine(ShowPanel(RegisterbanPanel));
        LoginbanPanel.transform.DOScale(0, 1);
        RegisterbanPanel.transform.DOScale(1, 1);
        
    }
    /// <summary>
    /// 响应开始游戏按钮的点击
    /// </summary>
    public void StartGameBtnClick()
    {
        BGImage.sprite = Resources.Load<Sprite>("BGImage/BG1");
        Destroy(AudioSourceBG);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickA");
        MainPanel.SetActive(false);
        RegisterbanPanel.SetActive(true);
        LoginbanPanel.SetActive(true);
    }

    /// <summary>
    /// 响应注册按钮的点击
    /// </summary>
    public void RegisterSetData()
    {
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickA");
        if (RegisterPasswordIF.text == CFRegisterPasswordIF.text)
        {
            SocketConnect.Instance.SendMessageToServer("请求注册/" + RegisterPlayerNameIF.text + "/" + RegisterPasswordIF.text);
            StartCoroutine(Register());
        }
        else
        {
            PromptMessage("两次输入的密码不一致，请重新输入");
        }

    }
    /// <summary>
    /// 注册协程
    /// </summary>
    /// <returns></returns>
    IEnumerator Register()
    {
        yield return new WaitForSeconds(0.1f);
        if (SocketConnect.IsRegister)
        {
            PromptMessage("注册成功，返回登录");
        }
        else
        {
            PromptMessage("用户名已存在，请重新注册");
        }
    }
    /// <summary>
    /// 响应退出按钮的点击
    /// </summary>
    public void BackBtnClick()
    {
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickA");
        Debug.Log("注册退出按钮");
        //StartCoroutine(HidePanel(RegisterbanPanel));
        //StartCoroutine(ShowPanel(LoginbanPanel)); 
        LoginbanPanel.transform.DOScale(1, 1);
        RegisterbanPanel.transform.DOScale(0, 1);
    }

    /// <summary>
    /// 面板提示信息公共方法
    /// </summary>
    /// <param name="s"></param>
    public void PromptMessage(string s)
    {
        Message.text = s;
        MessagePanel.DOLocalMoveY(125.1f, 0.5f);
        IsHide = true;
    }
    /// <summary>
    /// 协程--隐藏面板
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    IEnumerator HidePanel(GameObject g)
    {
        yield return new WaitForSeconds(FloWaitTime);
        g.SetActive(false);
    }
    /// <summary>
    /// 协程--显示面板
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    IEnumerator ShowPanel(GameObject g)
    {
        yield return new WaitForSeconds(FloWaitTime);
        g.SetActive(true);
    }

}

