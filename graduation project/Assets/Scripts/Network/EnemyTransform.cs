/*
 * 所属层级：网络层
 * 脚本功能：处理敌人AI的位置，旋转同步
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransform : MonoBehaviour {

    private GameObject Enemy;
    public GameObject EnemyPrefab;
    public Transform EnemyBeginPos;
    private NetTransform Tran;
    public string PlayerID;
    public static EnemyTransform Instance;
    private string message;
    private C_PlayerAnim playeranim;
    
    void Awake()
    {
        Instance = this;
    }

    void Start () {
        Tran = GameObject.Find("GreateWarrior").GetComponent<NetTransform>();
        playeranim = GameObject.Find("GreateWarrior").GetComponent<C_PlayerAnim>();
        Enemy = GameObject.Instantiate(EnemyPrefab, EnemyBeginPos.position, Quaternion.identity);
        PlayerID = SocketConnect.PlayerID;
        //InvokeRepeating("SocketConnect.Instance .SendMessageToServer(ConbinedSendData())", 0, 2);
    }
	
	
	void Update () {
      //  if (Math.Abs(Input.GetAxis("Horizontal")) > 0.1 || Math.Abs(Input.GetAxis("Vertical")) > 0.1)
       // {
           SocketConnect.Instance .SendMessageToServer(ConbinedSendData());
           
       // }
        message = SocketConnect.PosMessage;
        //Debug.Log(message);
        JudgePos(message);


    }
    /// <summary>
    /// 判断位置
    /// </summary>
    /// <param name="Message"></param>
    public void JudgePos(string Message)
    {
   
        if (Globe.StringSplit(Message, "/")[1] == "Pos")
        {

            if (Globe.StringSplit(Message, "/")[0] != PlayerID)
            {
                Enemy.transform.position = StringtoPos(Message, Convert.ToChar("/"));
                Enemy.transform.localEulerAngles = StringtoRotation(Message, Convert.ToChar("/"));
                 C_EnemyAnim.Instance .AnimatorManager(Globe.StringSplit(Message, "/")[6], 
                    Globe.StringSplit(Message, "/")[7], Globe.StringSplit(Message, "/")[8],
                    Globe.StringSplit(Message, "/")[9], Globe.StringSplit(Message, "/")[10]);

                V_FightUI.Instance.PlayerHPShow(float.Parse(Globe.StringSplit(Message, "/")[11]));
            }
        }
        
    }
    /// <summary>
    /// 组拼位置字符串
    /// id/pos/x/y/z/ry/iswork/isrun/isnormalattack/attackA/attackB/HP
    /// 客户端标识/位置字符/X/Y/Z/旋转/走的动画/跑的动画/普通攻击/技能A/技能B/血量
    /// </summary>
    /// <returns></returns>
    public string ConbinedSendData()
    {
        string str = "";
        str = PlayerID + "/" + Tran.Transformtobyte()+playeranim.EnemyAnimState()+"/"+C_FightAttack.HpSlider.ToString();
        return str;
    }
    /// <summary>
    /// 消息转化成位置信息
    /// </summary>
    /// <param name="s"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public Vector3 StringtoPos(string s, char c)
    {
        string[] strArr = s.Split(c);
        Vector3 V = new Vector3(Convert.ToSingle(strArr[2]), Convert.ToSingle(strArr[3]), Convert.ToSingle(strArr[4]));
        return V;
    }
    /// <summary>
    /// 消息转化成旋转信息
    /// </summary>
    /// <param name="s"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public Vector3 StringtoRotation(string s, char c)
    {
        string[] strArr = s.Split(c);
        Vector3 V = new Vector3(0, Convert.ToSingle(strArr[5]), 0);
        return V;
    }
     
}
