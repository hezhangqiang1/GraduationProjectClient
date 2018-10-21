/*  所属层级：数据层
 *  脚本功能：存储装备等级及个数
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_EquipmentItemInfo{

    private M_EquipmentInfo _equipmentInfo;
    private int level;//装备等级
    private int count=1;//物品个数

    public static M_EquipmentItemInfo _instance;

    void Awake()
    {
        _instance = this;
    }

    public M_EquipmentInfo EquipmentInfo
    {
        get { return _equipmentInfo; }
        set { _equipmentInfo = value; }
    }
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public int Count
    {
        get { return count; }
        set { count = value; }
    }
}
