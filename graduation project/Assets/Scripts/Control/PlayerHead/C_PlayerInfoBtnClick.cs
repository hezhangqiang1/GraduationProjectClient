/* 所属层级：控制层
 * 脚本功能：控制主角头像各个按钮的点击事件
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlayerInfoBtnClick : MonoBehaviour {
    public GameObject HeadInfo;//头像信息
    public GameObject NewNameInfo;//输入新名字面板
    public InputField NewNameInput;//新名字的输入框



	void Start () {
     
	}
	
	
	void Update () {
		
	}
    void OnDestroy()
    {
       
    }
    //响应头像的点击
    public void HeadBtnClick()
    {
        HeadInfo.SetActive(true);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
    //响应头像退出按钮
    public void HeadExit()
    {
        HeadInfo.SetActive(false);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
    //响应改名按钮的点击
    public void ChangePlayerNameBtnClick()
    {
        NewNameInfo.SetActive(true);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
    //响应确定改名的按钮点击
    public void DetermineNewNameBtnClick()
    {
        M_PlayerInfo._instance.ChangeNewName(NewNameInput.text);
        NewNameInfo.SetActive(false);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
    //响应取消改名按钮的点击
    public void CancelNewNameBtnClick()
    {
        NewNameInfo.SetActive(false);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
   
    
}
