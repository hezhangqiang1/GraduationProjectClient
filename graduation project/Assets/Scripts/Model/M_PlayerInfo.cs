/* 所属层级：数据层 
 * 脚本功能：主角的所有信息，主角的等级 姓名，战力，经验等等数据的整合
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PlayerInfo : MonoBehaviour
{
    /// <summary>
    /// 枚举用来判断数据类型
    /// </summary>
    public enum DataType
    {
        Name,//用户名
        Head,//头像名
        Level,//等级
        Power,//战力
        Experience,//经验
        DiamondNum,//宝石
        GoldNum,//金币
        StrengthNum,//体力
        ExpNum,//历练
        Hp,//生命
        Demage,//伤害
        Equip,//装备
        All//所有

    }

    public static M_PlayerInfo _instance;//本类实例


    #region 人物属性数据
    private string _name; //姓名
    private string _head; //头像 
    private int _level;  //等级
    private int _power; //战斗力
    private int _experience;//经验数
    private int _diamondNum;//钻石数
    private int _goldnum; //金币数
    private int _strengthnum;//体力数
    private int _expnum;//历练数
    private int _maxExperience;//升下一级所需的经验

    private int _hp;//生命值
    private int _demage=0;//伤害值
    private int _helmID=0;//头盔
    private int _clothID=0;//衣服
    private int _weaponID=0;//武器
    private int _shoesID=0;//鞋子
    private int _necklaceID=0;//项链
    private int _braceletID=0;//手镯
    private int _ringID=0;//戒指
    private int _wingID=0;//翅膀

    private int _bigstrength;//大体力丹
    private int _shortStrength;//小体力丹
    private int _chest;//宝箱

    #endregion
    #region Get and Set方法
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public string Head
    {
        get
        {
            return _head;

        }
        set
        {
            _head = value;
        }
    }
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }
    public int Power
    {
        get
        {
            return _power;
        }
        set
        {
            _power = value;
        }
    }
    public int Experience
    {
        get
        {
            return _experience;
        }
        set
        {
            _experience = value;
        }
    }
    public int DiamondNum
    {
        get
        {
            return _diamondNum;

        }
        set
        {
            _diamondNum = value;
        }
    }
    public int GoldNum
    {
        get
        {
            return _goldnum;
        }
        set
        {
            _goldnum = value;
        }
    }
    public int StrengthNum
    {
        get
        {
            return _strengthnum;
        }
        set
        {
            _strengthnum = value;
        }
    }
    public int ExpNum
    {
        get
        {
            return _expnum;
        }
        set
        {
            _expnum = value;
        }
    }
    public int MaxExpenience
    {
        get
        {
            return _maxExperience;
        }
        set
        {
            _maxExperience = value;
        }
    }
    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
    public int Demage
    {
        get { return _demage; }
        set { _demage = value; }
    }
    public int HelmID
    {
        get { return _helmID; }
        set { _helmID = value; }
    }
    public int ClothID
    {
        get { return _clothID; }
        set { _clothID = value; }
    }
    public int WeaponID
    {
        get { return _weaponID; }
        set { _weaponID = value; }
    }
    public int ShoesID
    {
        get { return _shoesID; }
        set  { _shoesID = value; }
    }
    public int NecklaceID
    {
        get { return _necklaceID; }
        set { _necklaceID = value; }
    }
    public int BraceletID
    {
        get { return _braceletID; }
        set { _braceletID = value; }
    }
    public int RingID
    {
        get { return _ringID; }
        set { _ringID = value; }
    }
    public int WingID
    {
        get { return _wingID; }
        set { _wingID = value; }
    }
    public int BigStrength
    {
        get { return _bigstrength; }
        set { _bigstrength = value; }
    }
    public int ShortStrength
    {
        get { return _shortStrength; }
        set { _shortStrength = value; }
    }
    public int Chest
    {
        get { return _chest; }
        set { _chest = value; }
    }
    #endregion
    #region 单例模式获取本类实例 
   
    /// <summary>
    ///单例模式获取本类实例 
    /// </summary>
    /// <returns></returns>
    //public static  M_PlayerInfo GetInsance()
    //{
    //    if(_instance==null)
    //    {
    //        _instance = new M_PlayerInfo();
    //    }
    //    return _instance;
    //}
    #endregion

    public delegate void ChangeInfoEvent(DataType data); //声明委托
    public  event ChangeInfoEvent ChangeInfo;//定义数据信息改变的事件 

    void Start()
    {
       // _instance = this;
        Init();
    }
    void Awake()
    {
        _instance = this;
    }
    /// <summary>
    /// 初始化数据
    /// </summary>
    public void Init()
    {
        this.Name = C_StartMenu.PlayerName;
        this.Head = "BOY";
        this.Level = 1;
        this.Power = 1000;
        this.Experience = 2;
        this.DiamondNum = 10;
        this.GoldNum = 1000;
        this.StrengthNum = 80;
        this.ExpNum = 50;
        this.MaxExpenience = 10;

        this.BraceletID = 1001;
        this.WingID = 1002;
        this.RingID = 1003;
        this.ClothID = 1004;
        this.HelmID = 1005;
        this.WeaponID = 1006;
        this.NecklaceID = 1007;
        this.ShoesID = 1008;
        this._chest = 1019;
        this._bigstrength = 1018;
        this._shortStrength = 1017;

        InitHPDemagePower();
        if (ChangeInfo != null)
        {
            ChangeInfo(DataType.All);
        }

    }
    //修改姓名的方法
    public void ChangeNewName(string NewName)
    {
        this.Name = NewName;
        ChangeInfo(DataType.Name);
    }
    //修改最大经验值(升级的时候调用)
    //TODO
    public void ChangeExperience()
    {
        this.MaxExpenience = UIShowTool.Instance.CalculateExperience(this.Level);
        Debug.Log(this.MaxExpenience);
        ChangeInfo(DataType.Experience);

    }
    /// <summary>
    /// 穿上装备
    /// </summary>
    /// <param name="id"></param>
    public void PutOnEquipment(int id)
    {
        if (id == 0) return;
        M_EquipmentInfo enquipmentInfo = null ;
        C_EquipManager._instance.DicequipInfo.TryGetValue(id, out enquipmentInfo);
        this.Hp += enquipmentInfo.Hp;
        this.Demage += enquipmentInfo.Demage;
        this.Power += enquipmentInfo.Power;
    }
    /// <summary>
    /// 脱下装备
    /// </summary>
    /// <param name="id"></param>
    public void PutOffEquipment(int id)
    {
        if (id == 0) return;
        M_EquipmentInfo enquipmentInfo = null;
        C_EquipManager._instance.DicequipInfo.TryGetValue(id, out enquipmentInfo);
        this.Hp -= enquipmentInfo.Hp;
        this.Demage -= enquipmentInfo.Demage;
        this.Power -= enquipmentInfo.Power;
    }
    /// <summary>
    /// 根据是否穿上装备来初始化血量，伤害，战力
    /// </summary>
    public void InitHPDemagePower()
    {
        this.Hp = this.Level * 100;
        this.Demage = this.Level * 50;
        this.Power = this.Hp + this.Demage;

        PutOnEquipment(BraceletID);
        PutOnEquipment(WingID);
        PutOnEquipment(RingID);
        PutOnEquipment(ClothID);
        PutOnEquipment(HelmID);
        PutOnEquipment(WeaponID);
        PutOnEquipment(NecklaceID);
        PutOnEquipment(ShoesID);

    }
}
