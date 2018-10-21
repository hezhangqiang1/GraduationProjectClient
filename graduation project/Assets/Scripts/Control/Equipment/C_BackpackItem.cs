/*  所属层级：控制层
 *  脚本功能：管理物品栏的信息
 *  
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_BackpackItem : MonoBehaviour {

    private Image image;//本身的图片
    private Button button;
    public  M_EquipmentInfo EI = null;
    private  Text CountText;//物品的个数




    void Start () {
        image = this.GetComponent<Image>();
        button = this.GetComponent<Button>();
        CountText = this.GetComponentInChildren<Text>();
        //Debug.Log(CountText.text);
        button.onClick.AddListener(delegate () { EquipItemBtnClick(EI); });
        M_PlayerInfo._instance.ChangeInfo += ItemInfoChange;
    }

    void OnDestroy()
    {
        M_PlayerInfo._instance.ChangeInfo -= ItemInfoChange;
    }
    void Update () {
		
	}
    public void ItemInfoChange(M_PlayerInfo.DataType data)
    {

        if (data == M_PlayerInfo.DataType.Hp || data == M_PlayerInfo.DataType.Demage
            || data == M_PlayerInfo.DataType.All || data == M_PlayerInfo.DataType.Equip)
        {
            UpdateUI();
        }
    }
    //更新面板显示
    void UpdateUI()
    {
        M_PlayerInfo Info = M_PlayerInfo._instance;
        int[] ItemName = { Info.HelmID,Info.WeaponID,Info.WingID,Info.NecklaceID,
        Info.RingID,Info.BraceletID,Info.ClothID ,Info.BigStrength,Info.ShoesID,Info.ShortStrength,Info.Chest };
        int i = Random.Range(0, 11);
        SetItem(ItemName[i]);
        SetItemCount();
        //Debug.Log(image.sprite.name );
       
        C_EquipManager._instance.DicequipInfo.TryGetValue(ItemName[i],out EI);
        //Debug.Log(EI.Price);
       
    }
    /// <summary>
    /// 设置图片
    /// </summary>
    /// <param name="id">物品ID</param>
    public void SetItem(int id)
    {
      
        M_EquipmentInfo equipmentInfo = null;
        bool IsExit = C_EquipManager._instance.DicequipInfo.TryGetValue(id, out equipmentInfo);
        if (IsExit)
        {
            image.sprite = Resources.Load<Sprite>("ItemImage/" + equipmentInfo.IconName);
           // Debug.Log(image.sprite);
        }
       
    }
    public void SetItemCount()
    {
        M_EquipmentItemInfo info = new M_EquipmentItemInfo();
        CountText.text = info.Count .ToString ();
    }
    /// <summary>
    /// item的点击事件
    /// </summary>
    private void EquipItemBtnClick(M_EquipmentInfo M)
    {
        if (M.InventoryTYPE == InventoryType.Equip)
        {
            V_BackpackItem._instance.UpdateUI(M.Name, M.Quality, M.Demage, M.Hp, M.Power, M.Des);
        }
        if(M.InventoryTYPE == InventoryType.Drug)
        {
            V_BackpackItem._instance.ShowUI(M.Name, M.Des);
        }
       
        
    }
}
