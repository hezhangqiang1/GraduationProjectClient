/*
 * 所属层级：控制层
 * 脚本功能：攻击的判断 不同技能的伤害计算
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_FightAttack : MonoBehaviour {

    private GameObject EnemyPrefab;
    private Transform EnemyTransform;
    private bool IsDoOne;

    public static float HpSlider=1;
    public static C_FightAttack Instance;


    void Awake()
    {
        Instance = this;
    }
	void Start () {
        EnemyPrefab = GameObject.FindGameObjectWithTag("Enemy");
        InvokeRepeating("AttackCalculate", 0, 1);
        
	}
	
	
	void Update () {
        EnemyTransform = EnemyPrefab.transform;
        //AttackCalculate();
        //Debug.Log(HpSlider);
        //SocketConnect.Instance.SendMessageToServer(SocketConnect.PlayerID + "/" + "血量" + "/" + HpSlider.ToString());
        //Debug.Log(SocketConnect.PlayerID + "/" + "血量" + "/" + HpSlider.ToString());
	}
    /// <summary>
    /// 各种攻击方式的计算方法
    /// </summary>
    public void AttackCalculate()
    {
       
        //普通攻击的计算 距离小于2 面向敌人
        if (C_PlayerAnim.IsNormalAttack == 1)
        {
            if (Vector3.Distance(this.transform.position, EnemyTransform.position) < 2f &&
                Mathf.Sign(Vector3.Dot( transform.forward, (EnemyTransform.position - transform.position)))>0)
            {    
                M_FightInfo.Instance.HP-=100;
                Debug.Log("敌人受到100点技能A的伤害,敌人剩余血量" + M_FightInfo.Instance.HP.ToString());
                HpSlider = M_FightInfo.Instance.HP / 2000F;
            }
        }
        //技能A的计算
        if (C_PlayerAnim.IsAttackSkillA == 1)
        {
            if (Vector3.Distance(this.transform.position, EnemyTransform.position) < 2f &&
               Mathf.Sign(Vector3.Dot(transform.forward, (EnemyTransform.position - transform.position))) > 0)
            {
               
                M_FightInfo.Instance.HP -= 300;
                Debug.Log("敌人受到300点技能A的伤害,敌人剩余血量"+ M_FightInfo.Instance.HP.ToString());
                HpSlider = M_FightInfo.Instance.HP / 2000F;
            }
        }
        //技能B的计算
        if (C_PlayerAnim.IsAttackSkillB == 1)
        {
            if (Vector3.Distance(this.transform.position, EnemyTransform.position) < 2f &&
               Mathf.Sign(Vector3.Dot(transform.forward, (EnemyTransform.position - transform.position))) > 0)
            {
                M_FightInfo.Instance.HP -= 500;
                Debug.Log("敌人受到500点技能A的伤害,敌人剩余血量" + M_FightInfo.Instance.HP.ToString());
                HpSlider = M_FightInfo.Instance.HP / 2000F;
            }
        }

    }
    /// <summary>
    /// 战斗结算
    /// </summary>
    /// <param name="hp"></param>
    public void CombatSettlement(string WinPlayerID,string MyID)
    {
        if (WinPlayerID == MyID)
        {
            V_FightUI.Instance.FightResultShow("YOU WIN");
        }
        else
        {
            V_FightUI.Instance.FightResultShow("YOU LOSE");
        }
    }
}
