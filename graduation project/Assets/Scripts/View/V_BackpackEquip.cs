/* 视图层
 * 显示装备栏UI
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class V_BackpackEquip : MonoBehaviour {

    public Image HelmImage;
    public Image ClothImage;
    public Image WeaponImage;
    public Image ShoesImage;
    public Image NecklaceImage;
    public Image BraceletImage;
    public Image RingImage;
    public Image wingImage;

    public Text HPText;
    public Text DemageText;

    void Start()
    {
        M_PlayerInfo._instance.ChangeInfo += EquipInfoChange;
    }
    void OnDestroy()
    {
        M_PlayerInfo._instance.ChangeInfo -= EquipInfoChange;
    }
    public void EquipInfoChange(M_PlayerInfo.DataType data)
    {
        if (data == M_PlayerInfo.DataType.Hp || data == M_PlayerInfo.DataType.Demage
            || data == M_PlayerInfo.DataType.All || data == M_PlayerInfo.DataType.Equip)
        {
            UpdateUI();
        }
    }
    /// <summary>
    /// 更新背包显示
    /// </summary>
    void UpdateUI()
    {
        M_PlayerInfo Info = M_PlayerInfo._instance;
        HelmImage.GetComponent<C_BackPackEquip>().SetID(Info.HelmID);
        ClothImage.GetComponent<C_BackPackEquip>().SetID(Info.ClothID );
        WeaponImage .GetComponent<C_BackPackEquip>().SetID(Info.WeaponID );
        ShoesImage.GetComponent<C_BackPackEquip>().SetID(Info.ShoesID );
        NecklaceImage .GetComponent<C_BackPackEquip>().SetID(Info.NecklaceID );
        BraceletImage .GetComponent<C_BackPackEquip>().SetID(Info.BraceletID );
        RingImage .GetComponent<C_BackPackEquip>().SetID(Info.RingID );
        wingImage.GetComponent<C_BackPackEquip>().SetID(Info.WingID);

        HPText.text = Info.Hp.ToString ();
        DemageText.text = Info.Demage .ToString();
    }
}
