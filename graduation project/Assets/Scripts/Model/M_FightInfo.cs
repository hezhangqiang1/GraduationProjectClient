/*
 * 所属层级：数据层 
 * 脚本功能：角色的血量，攻击力等数据信息
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_FightInfo : MonoBehaviour {
    private string id;
    private string username;
    private int hp;
    private int demage;
    private int defance;
    private int speed;

    public static M_FightInfo Instance;

  
    #region  构造函数
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    public string UserName
    {
        get { return username; }
        set { username = value; }
    }
    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Demage
    {
        get { return demage; }
        set { demage = value; }
    }
    public int Defance
    {
        get { return defance; }
        set { defance = value; }
    }
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
#endregion

    void Awake()
    {
        Instance = this;
    }
    void Start () {
        Init();
	}

	void Update () {
       // Debug.Log(HP);
	}
    /// <summary>
    /// 数据的初始化
    /// </summary>
    public void Init()
    {
        this.ID = SocketConnect.PlayerID;
        this.UserName = C_StartMenu.PlayerName;
        //TODO 数据从数据库拿
        this.HP = 2000;
        this.Demage = 1000;
        this.Defance = 800;
        this.Speed = 300;
    }
}
