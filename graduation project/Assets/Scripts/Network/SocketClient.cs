/*
 * Socket客户端 连接服务器
 * 功能：进行简单的数据传输 
 *       开始匹配位置旋转同步
 *       技能处理伤害处理
 *       
 * 注：这个脚本要被弃用，帧同步不是直接同步位置和旋转而是同步操作指令
 *     房间匹配改为直接匹配
 */

using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SocketClient : MonoBehaviour {
   
    private Socket clientSocket;
    private byte[] data = new byte[1024];
   // private byte[] PosData = new byte[1024];
    private byte[] IDdata = new byte[1024];
    public Text playerIDText;
    public Text RoomName;

    public Vector3 Pos;
    public GameObject EnemyPrefab;
    public Transform EnemyBeginPos;
    public static string PlayerID;
    public string SendData;
    public string ServerMessage;
    public string RoomID;
    public string RoomMessage;
    private NetTransform Tran;
    private GameObject Enemy;

    public static SocketClient Instance;
    void Awake()
    {
        ConnectServer();
        Instance = this;
    }
    void Start () {
        
        Tran = GameObject.Find("GreateWarrior").GetComponent<NetTransform>();
        //ReceiveMessageFromServer();
        // InvokeRepeating("ReceiveMessageFromServer", 1, 1);
        Loom.Initialize();
        Enemy = GameObject.Instantiate(EnemyPrefab, EnemyBeginPos.position, Quaternion.identity);
    }
	
	void Update () {
        SendMymessage(ConbinedSendData());
        playerIDText.text = PlayerID;
        //RoomName.text = RoomID+ "的房间";

    }
    /// <summary>
    /// 客户端关闭执行的方法
    /// </summary>
    void OnDestroy()
    {
        clientSocket.Shutdown(SocketShutdown.Both);
    }
    /// <summary>
    ///连接服务器的方法
    /// </summary>
   public  void ConnectServer()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.111"),7788));
        int id = clientSocket.Receive(IDdata);
        string ids= Encoding.UTF8.GetString(IDdata, 0, id);
        PlayerID = StringSplit(ids, Convert.ToChar(":"))[1];
        ////创建一个新的线程 用来接收消息
        Thread t = new Thread(ReceivePosMessage);
         t.Start();
         
    }
    #region 同步接收消息

    //void ReceiveMymessage()
    //{
    //    while (true)
    //    {
    //        if (clientSocket.Connected == false)
    //        {
    //            break;
    //        }
    //        int length = clientSocket.Receive(data);
    //        ServerMessage = Encoding.UTF8.GetString(data, 0, length);
    //        //PlayerID = StringSplit(ServerMessage, Convert.ToChar(":"))[1];
    //        Debug.Log("收到服务器消息" + ServerMessage);
    //    }
    //}
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
            });
        }
        
       
    }
    #endregion
    #region 异步接收消息
    //void ReceiveMessageFromServer()
    //{
    //   // if (clientSocket.Connected == true)
    //   // {
    //        clientSocket.BeginReceive(data,0,data.Length,SocketFlags.None,ReceiceCallBack,clientSocket);
    //   // }
    //}
    //void ReceiceCallBack(IAsyncResult result)
    //{
    //    int count = clientSocket.EndReceive(result);
    //    ServerMessage = Encoding.UTF8.GetString(data, 0, count);
    //    Debug.Log("收到服务器消息"+ServerMessage);
    //    PlayerID = StringSplit(ServerMessage, Convert.ToChar(":"))[1];
    //    Debug.Log("玩家ID"+PlayerID);
    //    clientSocket.BeginReceive(data, 0, data.Length, SocketFlags.None, ReceiceCallBack, clientSocket);
    //}
    #endregion

    /// <summary>
    /// 向服务器发送消息的方法
    /// </summary>
    /// <param name="Mymessage"></param>
   public  void SendMymessage(string Mymessage) {
        //简单字节流协议 
        //TODO 加入字节流长度 提取方法
        byte[] senddata = Encoding.UTF8.GetBytes(Mymessage);
        //byte[] length = BitConverter.GetBytes(data.Length);
        //byte[] senddata = length.Concat(data).ToArray();
        if (Math.Abs(Input.GetAxis("Horizontal"))>0.1||Math.Abs(Input.GetAxis("Vertical"))>0.1)
        {
            clientSocket.Send(senddata);
            // Debug.Log("发送位置消息" + Mymessage);
        }
   
    }
    /// <summary>
    /// 判断服务器信息
    /// </summary>
    /// <param name="Message">要判断的消息</param>
    public void JudgeMessage(string Message)
    {
        //if (StringSplit(Message, Convert.ToChar("/"))[0] == "DB")
        //{
        //    Debug.Log("收到数据库消息" + Message);
        //}
        if (StringSplit(Message, Convert.ToChar("/"))[1] == "Pos")
        {
           
            //TODO  技能同步
            if (StringSplit(Message, Convert.ToChar("/"))[0] != PlayerID)
            {
                
               // Debug.Log("收到敌人位置信息" + Message);
               // Enemy= GameObject.Instantiate(EnemyPrefab, EnemyBeginPos.position, Quaternion.identity);
                Enemy.transform.position = StringtoPOS(Message, Convert.ToChar("/"));
                // Enemy.transform.rotation = Quaternion.LookRotation( StringtoRotation(Message, Convert.ToChar("/")));
                Enemy.transform.localEulerAngles = StringtoRotation(Message, Convert.ToChar("/"));
                Debug.Log(StringtoRotation(Message, Convert.ToChar("/")));
               // Debug.Log("敌人位置" + Enemy.transform.position);
            }
           
        }
        if (StringSplit(Message, Convert.ToChar("/"))[1] == "Room")
        {
            RoomID = StringSplit(Message, Convert.ToChar("/"))[1];
        }
        
    }
    #region 房间功能
    ///// <summary>
    ///// 创建房间
    ///// </summary>
    //public void CreateRoom()
    //{
    //    byte[] Room = Encoding.UTF8.GetBytes(PlayerID + "Room/" +"/要创建房间");
    //    clientSocket.Send(Room);
    //    //int DataLength = clientSocket.Receive(data);
    //    //RoomMessage = Encoding.UTF8.GetString(data, 0, DataLength);
    //    //if (StringSplit(RoomMessage, Convert.ToChar("/"))[0] == "Room")
    //    //{
    //    //    Debug.Log("收到创建房间消息" + RoomMessage);
    //    //    RoomID = StringSplit(RoomMessage, Convert.ToChar("/"))[1];
    //    //}
    //}
    ///// <summary>
    ///// 刷新房间
    ///// </summary>
    //public void FlashRoomBtnClick()
    //{
    //    //RoomID = StringSplit(RoomMessage, Convert.ToChar("/"))[1];
    //    RoomName.text = RoomID + "开的房间";
    //    Debug.Log(PlayerID+"刷新房间"+"新加入"+RoomID+"的房间");
    //}

    //public void EnterRoom()
    //{
    //    //TODO
    //}
#endregion
    /// <summary>
    /// 消息转化成位置信息
    /// </summary>
    /// <param name="s"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public Vector3 StringtoPOS(string s,char c)
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
    public Vector3 StringtoRotation(string s,char c)
    {
        string[] strArr = s.Split(c);
        Vector3 V = new Vector3(0, Convert.ToSingle(strArr[5]), 0);
        return V;
    }
    /// <summary>
    /// 分割字符串
    /// </summary>
    /// <param name="s">要分割的字符串</param>
    /// <param name="c">分割条件</param>
    /// <returns></returns>
    public string[] StringSplit(string s, char c)
    {
        string[] strArr = s.Split(c);
        return strArr;
    }
    /// <summary>
    /// 组拼位置字符串
    /// </summary>
    /// <returns></returns>
    public string ConbinedSendData()
    {
        string str = "";
        str = PlayerID + "/" + Tran.Transformtobyte();
        return str;
    }

}

