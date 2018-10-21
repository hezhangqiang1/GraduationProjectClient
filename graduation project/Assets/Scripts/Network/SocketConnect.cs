/*
 * Socket客户端 连接服务器
 * 提供发送消息和接收消息的方法
 */

using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Threading;
using UnityEngine;
using System;


public class SocketConnect : MonoBehaviour
{
    public Socket clientSocket;
    public static SocketConnect Instance;
    public static bool IsLogin;
    public static bool IsRegister;
    public static bool IsStartFight;
    public static bool IsOnline;
    public static string PlayerID;
    public static string PosMessage;
    private  byte[] data = new byte[1024];
    private byte[] IDdata = new byte[1024];

    

    void Awake()
    {
        if (Instance != null) return;
        Instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
       
        ConnectServer();
        Loom.Initialize();
    }
    void Update()
    {
       // Debug.Log(PlayerID);
    }
    /// <summary>
    ///连接服务器的方法
    /// </summary>
    public void ConnectServer()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.56.1"), 7788));
        int id = clientSocket.Receive(IDdata);
        string ids = Encoding.UTF8.GetString(IDdata, 0, id);
        PlayerID = Globe. StringSplit(ids, ":")[1];

        Thread t = new Thread(ReceivePosMessage);
        t.Start();
    }
    /// <summary>
    /// 向服务器发送消息的方法
    /// </summary>
    /// <param name="Mymessage"></param>
    public  void SendMessageToServer(string Mymessage)
    {
        //TODO 协议设计 数据长度 粘包分包
        byte[] senddata = Encoding.UTF8.GetBytes(Mymessage);
        clientSocket.Send(senddata);

    }

    /// <summary>
    /// 用来循环接收消息
    /// </summary>
    void ReceivePosMessage()
    {

        while (true)
        {
            if (clientSocket.Connected == false)
            {
                break;
            }
            int DataLength = clientSocket.Receive(data);
            string ServerMessage = Encoding.UTF8.GetString(data, 0, DataLength);
            Loom.QueueOnMainThread(() => {
                JudgeMessage(ServerMessage);
                PosMessage = ServerMessage;
            });
        }


    }
    /// <summary>
    /// 判断服务器消息
    /// </summary>
    /// <param name="Message"></param>
    public void JudgeMessage(string Message)
    {
        if (Globe.StringSplit(Message,"/")[0] == "DB")
        {
            Debug.Log("收到数据库消息" + Message);
        }
        if (Globe.StringSplit(Message, "/")[0] == "战斗结算")
        {
            C_FightAttack.Instance.CombatSettlement(Globe.StringSplit(Message, "/")[1], PlayerID);
        }
        if (Message == "登录成功")
        {
            IsLogin = true;
        }
        if (Message == "登录失败")
        {
            IsLogin = false;
        }
        if (Message == "当前用户在线")
        {
            IsOnline = true;
        }
        if (Message == "注册成功")
        {
            IsRegister = true;
        }
        if (Message == "注册失败")
        {
            IsRegister = false;
        }
        if (Message == "开始游戏")
        {
            IsStartFight = true;
        }

        //if (Globe.StringSplit(Message, "/")[1] == "血量")
        //{
        //    V_FightUI.Instance.PlayerHPShow(float.Parse(Globe.StringSplit(Message, "/")[2]));
        //}

    }
    /// <summary>
    /// 客户端关闭执行的方法
    /// </summary>
    void OnDestroy()
    {
        clientSocket.Shutdown(SocketShutdown.Both);
    }

  
    
}