/* 所属层级：控制层
 * 脚本功能：读取物品信息清单
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EquipManager : MonoBehaviour {

    public static C_EquipManager _instance;
    public TextAsset EquipInfo;//物品信息清单
    //private M_EquipmentInfo equipmentInfo;

    public  Dictionary<int, M_EquipmentInfo> DicequipInfo = new Dictionary<int, M_EquipmentInfo> ();
    //public  Dictionary<int, M_EquipmentItemInfo> DicequipItemInfo = new Dictionary<int, M_EquipmentItemInfo>();
    public List<M_EquipmentItemInfo> DicequipItemInfo = new List<M_EquipmentItemInfo>();
    void Awake()
    {
        _instance = this;
        ReadEquipInfo();
        ReadEquipItemInfo();
    }
    //读取TXT信息，初始化物品信息
    void ReadEquipInfo()
    {
        string Str = EquipInfo.ToString();
        string[] StrInfoArray = Str.Split('\n');
        foreach(string strinfo in StrInfoArray)
        {

            string[] ItemStr = strinfo.Split('|');
            //Debug.Log(ItemStr);
            M_EquipmentInfo equipmentInfo = new M_EquipmentInfo () ;
            //ID 名称 图标 类型（Equip，Drug,Box） 装备类型(Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing)
            //售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述
            equipmentInfo.ID = int.Parse (ItemStr[0]);
            equipmentInfo.Name = ItemStr[1];
            equipmentInfo.IconName = ItemStr[2];
            switch (ItemStr[3])
            {
                case "Equip":
                    equipmentInfo.InventoryTYPE = InventoryType.Equip;
                    break;
                case "Drug":
                    equipmentInfo.InventoryTYPE = InventoryType.Drug;
                    break;
                case "Box":
                    equipmentInfo.InventoryTYPE = InventoryType.Box;
                    break;

            }
            switch (ItemStr[4])
            {
                case "Helm":
                    equipmentInfo.EquipTYPE = EquipType.Helm;
                    break;
                case "Cloth":
                    equipmentInfo.EquipTYPE = EquipType.Cloth;
                    break;
                case "Weapon":
                    equipmentInfo.EquipTYPE = EquipType.Weapon;
                    break;
                case "Shoes":
                    equipmentInfo.EquipTYPE = EquipType.Shoes;
                    break;
                case "Necklace":
                    equipmentInfo.EquipTYPE = EquipType.Necklace;
                    break;
                case "Bracelet":
                    equipmentInfo.EquipTYPE = EquipType.Bracelet;
                    break;
                case "Ring":
                    equipmentInfo.EquipTYPE = EquipType.Ring;
                    break;
                case "Wing":
                    equipmentInfo.EquipTYPE = EquipType.Wing;
                    break;
            }
            equipmentInfo.Price = int.Parse (ItemStr[5]);
            if(equipmentInfo.InventoryTYPE == InventoryType.Equip)
            {
                equipmentInfo.StarLevel = int.Parse(ItemStr[6]);
                equipmentInfo.Quality = int.Parse(ItemStr[7]);
                equipmentInfo.Demage = int.Parse(ItemStr[8]);
                equipmentInfo.Hp = int.Parse(ItemStr[9]);
                equipmentInfo.Power = int.Parse(ItemStr[10]);
            }
           
            if( equipmentInfo .InventoryTYPE== InventoryType.Drug)
            {
                equipmentInfo.ApplyValue = int.Parse(ItemStr[12]);
            }
            equipmentInfo.Des = ItemStr[13];
            DicequipInfo.Add(equipmentInfo.ID, equipmentInfo);
        }
    }//ReadEquipInfo()_end 
    //读取当前角色所拥有的信息
    void ReadEquipItemInfo()
    {
        
        //TODO 需要连接服务器获取当前角色的物品信息
        //Test：随机生成主角拥有的20个物品
        //for (int j = 0; j <= 20; j++)
        //{
        //    int id = Random.Range(1001, 1020);
        //    M_EquipmentInfo i = null;
        //    DicequipInfo.TryGetValue(id, out i);
           
        //    if (i.InventoryTYPE == InventoryType.Equip)
        //    {
        //        M_EquipmentItemInfo It = new M_EquipmentItemInfo();
        //        It.EquipmentInfo = i;
        //        It.Level = Random.Range(1, 10);
        //        It.Count = 1;
        //        DicequipItemInfo.Add( It);

        //    }
        //    else
        //    {
        //        //选判断背包里面是否已经存在
        //        M_EquipmentItemInfo It = null;
        //        bool IsExit = false;
        //        foreach (M_EquipmentItemInfo temp in DicequipItemInfo)
        //        {
        //            if(temp .EquipmentInfo.ID == id)
        //            {
        //                IsExit = true;
        //                It = temp;
        //                break;
        //            }
        //        }
        //        if (IsExit)
        //        {
        //            It.Count++;
        //        }
        //        else
        //        {
        //            It = new M_EquipmentItemInfo();
        //            It.EquipmentInfo = i;
        //            It.Count = 1;
        //            DicequipItemInfo.Add( It);
        //        }
            }
 }


