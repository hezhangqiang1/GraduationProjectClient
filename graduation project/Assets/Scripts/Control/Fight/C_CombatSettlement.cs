/*
 * 所属层级：控制层
 * 脚本功能：战斗结算
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_CombatSettlement : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {

    }
    /// <summary>
    /// 战斗结束后返回
    /// </summary>
    public void GameOverBackBtnClick()
    {
        Globe.nextSceneName = "002_NewVillage";
        SceneManager.LoadScene("Loading");
    }
}