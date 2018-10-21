/*
 * 所属层级：控制层
 * 脚本功能：实现敌人AI的动画，技能，特效等播放
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EnemyAnim : MonoBehaviour {

    private Animator EnemyAnimator;
    public static C_EnemyAnim Instance;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        EnemyAnimator = this.GetComponent<Animator>();
    }
    /// <summary>
    /// 敌人的动画管理
    /// </summary>
    /// <param name="iswork"></param>
    /// <param name="isrun"></param>
    /// <param name="isnormalattack"></param>
    /// <param name="attackA"></param>
    /// <param name="attackB"></param>
	public void AnimatorManager(string iswork,string isrun,string isnormalattack,string attackA,string attackB)
    {
        if (iswork == "1")
        {
            EnemyAnimator.SetBool("IsWork", true);
            
        }
        else
        {
            EnemyAnimator.SetBool("IsWork", false);
        }
        if (isrun == "1")
        {
            EnemyAnimator.SetBool("IsRun", true);
           
        }
        else
        {
            EnemyAnimator.SetBool("IsRun", false);
        }
        if (isnormalattack == "1")
        {
            EnemyAnimator.SetBool("IsAttack3-2", true);
            AudioClipManager._instance.PlayGameSoundByName("NormalAttack");
        }
        else
        {
            EnemyAnimator.SetBool("IsAttack3-2", false);
        }
        if (attackA == "1")
        {
            EnemyAnimator.SetFloat("IsAttack3-1", 1);
            AudioClipManager._instance.PlayGameSoundByName("AttackSkillA");
        }
        else
        {
            EnemyAnimator.SetFloat("IsAttack3-1", -1);
        }
        if (attackB=="1")
        {
            EnemyAnimator.SetFloat("IsAttack1", 1);
            AudioClipManager._instance.PlayGameSoundByName("AttackSkillB");
        }
        else
        {
            EnemyAnimator.SetFloat("IsAttack1", -1);
        }

    }
    }

