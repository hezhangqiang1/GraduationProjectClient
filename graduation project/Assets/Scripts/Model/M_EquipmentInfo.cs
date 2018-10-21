/*  所属层级：数据层
 *  脚本功能：存储装备信息
 *  
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{
    Equip,//装备
    Drug,//药物
    Box//箱子
}
public enum EquipType
{
    Helm,//头盔
    Cloth,//衣服
    Weapon,//武器
    Shoes,//鞋子
    Necklace,//项链
    Bracelet,//手镯
    Ring,//戒指
    Wing//翅膀

}

public class M_EquipmentInfo   {
    private int id;//ID
    private string Equipname;//名称
    private string iconName;//图片名称
    private InventoryType inventoryType;//物品类型
    private EquipType equipType;//装备类型
    private int price = 0;//价格
    private int starLevel = 1;//星级
    private int quality = 1;//品质
    private int demage = 0;//伤害
    private int hp = 0;//生命
    private int power = 0;//战斗力

    private M_PlayerInfo.DataType infoType;//作用类型（作用在哪个属性之上）
    private int applyValue;//作用值
    private string des;//描述

    //public static M_EquipmentInfo _instance;//本类实例
	
#region GET SET 方法
    public int ID
    {
        get { return id; }
        set { id = value; }
    }
	public string Name
    {
        get { return Equipname ; }
        set { Equipname  = value; }
    } 
    public string IconName
    {
        get { return iconName; }
        set { iconName = value; }
    }
    public InventoryType InventoryTYPE
    {
        get { return inventoryType; }
        set { inventoryType = value; }
    }
    public EquipType EquipTYPE
    {
        get { return equipType; }
        set { equipType = value; }
    }
   
    public int Price
    {
        get { return price; }
        set { price = value; }
    }
    public int StarLevel
    {
        get { return starLevel; }
        set { starLevel = value; }
    }
    public int Quality
    {
        get { return quality; }
        set { quality = value; }
    }
    public int Demage
    {
        get { return demage; }
        set { demage = value; }
    }
    public int Hp
    {
        get { return hp ; }
        set { hp = value; }
    }
    public int Power
    {
        get { return power; }
        set { power = value; }
    }
    public M_PlayerInfo.DataType InfoTYPE
    {
        get { return infoType; }
        set { infoType = value; }
    }
    public int ApplyValue
    {
        get { return applyValue; }
        set { applyValue = value; }
    }
    public string Des
    {
        get { return des; }
        set { des = value; }
    }
    #endregion
   //void Awake()
   // {
   //     _instance = this;
   // }
}

