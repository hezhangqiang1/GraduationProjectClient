/*
 * 所属层级：视图层
 * 脚本功能：显示战斗场景的UI
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class V_FightUI : MonoBehaviour {
    public  Slider PlayerHPSlider;
    public  Slider EnemyHPSlider;

    public Image AttackSkillA;
    public  Image AttackSkillB;
    public  Image NormalAttack;

    public  Slider AttackSkillASlider;
    public  Slider AttackSkillBSlider;
    public  Slider NormalAttackSlider;

    public static V_FightUI Instance;
    
    public GameObject FightResult;
    public Text Result;
    public Text PlayerNameText;
    public Text EnemyNameText;

    void Awake()
    {
        Instance = this;
    }
    void Start () {
        FightResult.transform.DOScale(0, 1);
       // PlayerNameText.text = C_StartMenu.PlayerName;
    }
	
	
	void Update () {
        CDSkillManager();
        EnemyHPShow();

    }
    /// <summary>
    /// 管理技能图标的表现
    /// </summary>
    public void CDSkillManager()
    {
        NormalAttackSlider.value = C_PlayerAnim.NormalATKCDTime / 2;
        if((C_PlayerAnim.NormalATKCDTime / 2) < 1)
        {
            NormalAttack.color = new Color(255, 255, 255, C_PlayerAnim.NormalATKCDTime / 2);
        }
        AttackSkillASlider.value = C_PlayerAnim.ATKCDTimeA / 4;
        if((AttackSkillASlider.value = C_PlayerAnim.ATKCDTimeA / 4) < 1)
        {
            AttackSkillA.color = new Color(255, 255, 255, AttackSkillASlider.value = C_PlayerAnim.ATKCDTimeA / 4);
        }
        AttackSkillBSlider.value = C_PlayerAnim.ATKCDTimeB / 8;
        if((C_PlayerAnim.ATKCDTimeB / 8) < 1)
        {
            AttackSkillB.color = new Color(255, 255, 255, C_PlayerAnim.ATKCDTimeB / 8);
        }
    }
    /// <summary>
    /// 敌人血量显示
    /// </summary>
    public void EnemyHPShow()
    {
        EnemyHPSlider.value = C_FightAttack.HpSlider;
        //Debug.Log(C_FightAttack.HpSlider);

    }
    /// <summary>
    /// 玩家血量同步
    /// </summary>
    /// <param name="hp"></param>
    public void PlayerHPShow(float hp)
    {
        PlayerHPSlider.value = hp;
    }
    /// <summary>
    /// 战斗结算面板
    /// </summary>
    /// <param name="result">结果</param>
    public void FightResultShow(string result)
    {
        Result.text = result;
        FightResult.SetActive(true);
        FightResult.transform.DOScale(1, 1);
    }
}
