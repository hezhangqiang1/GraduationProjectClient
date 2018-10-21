/* 所属层级：控制层
 * 脚本功能：控制创建角色各个按钮的点击事件
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_SelectShow : MonoBehaviour {

    public GameObject BoyRole;
    public GameObject GirlRole;
    public GameObject Boyban;
    public GameObject Girlban;

    public InputField RoleName;

	void Start () {
		
	}
	
	
	void Update () {
		
	}
    //响应男生角色按钮点击
    public void SelectBoyBtnClick()
    {
        BoyRole.SetActive(true);
        Boyban.SetActive(true);
        GirlRole.SetActive(false);
        Girlban.SetActive(false);
        
    }
    //响应女生角色按钮点击
    public void SelectGirlBtnClick()
    {
        BoyRole.SetActive(false );
        Boyban.SetActive(false );
        GirlRole.SetActive(true );
        Girlban.SetActive(true );
    }
    //响应确定创建按钮的点击
    public void ConfirmSelect()
    {
        //TODO
    }
}
