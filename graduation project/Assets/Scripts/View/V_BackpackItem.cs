/*
 * 视图层：
 * 控制装备信息显示
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class V_BackpackItem : MonoBehaviour {

    public static V_BackpackItem _instance;//本类实例
    public GameObject PopoverPanel;//体力丹信息显示
    public GameObject EquipPopoverPanel;//装备信息显示
    public Text EquipnameText;//装备名字
    public Text QuilityText;//品质
    public Text DemageText;//伤害
    public Text LifeText;//生命
    public Text PowerText;//战力
    public Text DescribeText;//描述

    public Text Name;//药品名字
    public Text Des;//药品描述

    void Awake()
    {
        _instance = this;
    }

    //展示装备类信息
    public void UpdateUI(string  equipname,int quility,int demage,int life,int power,string describe)
    {
        EquipPopoverPanel.SetActive(true);
        PopoverPanel.SetActive(false);
        EquipnameText.text =equipname;
        QuilityText.text = "品质："+quility;
        DemageText.text  = "伤害："+demage;
        LifeText.text = "生命："+life;
        PowerText.text = "战力："+power;
        DescribeText.text = describe;
    }
    /// <summary>
    /// 展示药品类信息
    /// </summary>
    /// <param name="des">药品描述</param>
    /// <param name="name">物品名字</param>
    public void ShowUI(string name,string des)
    {
        PopoverPanel.SetActive(true);
        EquipPopoverPanel.SetActive(false);
        Name.text = name;
        Des.text = des;

    }
    //响应装备信息退出按钮的点击
    public void ExitEquipButtonClick()
    {
        EquipPopoverPanel.SetActive(false);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
    //响应药品信息退出按钮的点击
    public void ExitItemButtonClick()
    {
        PopoverPanel.SetActive(false );
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
    
}
