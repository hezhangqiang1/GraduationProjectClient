/* 所属层级：控制层
 * 脚本功能：控制装备图片的显示
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_BackPackEquip : MonoBehaviour {
    private Image image;


    void Awake()
    {
        image = this.GetComponent<Image>();
    }
    /// <summary>
    /// 设置图片
    /// </summary>
    /// <param name="id"></param>
    public void SetID(int id)
    {
        M_EquipmentInfo equipmentInfo = null;
        bool IsExit = C_EquipManager._instance.DicequipInfo.TryGetValue(id, out equipmentInfo);
        if (IsExit)
        {
            if(image !=null )
            //image.name = equipmentInfo.IconName;
            //Debug.Log(image.name);
            // print("EquipImage/" + image.name);
            image.sprite = Resources.Load<Sprite>("EquipImage/" + equipmentInfo.IconName);
            //print(image.sprite);
           
        }
    }

}

