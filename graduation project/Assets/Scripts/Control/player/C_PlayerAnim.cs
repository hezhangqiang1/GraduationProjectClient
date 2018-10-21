/*
 * 所属层级：控制层
 * 脚本功能：控制角色的动画
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlayerAnim : MonoBehaviour {

    private Animator PlayAnimator;
    private Rigidbody _rigidbody;
    public static int  IsWork;
    public static int  IsRun;
    public static int IsNormalAttack;
    public static int IsAttackSkillA;
    public static int IsAttackSkillB;

    public  static  float NormalATKCDTime=0;
    public  static  float ATKCDTimeA=0 ;
    public  static  float ATKCDTimeB=0;

  

    void Start () {
        PlayAnimator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        AudioClipManager._instance.PlayAudioSourceBGByName("FightBG");
        //AudioClipManager._instance.SetAudioVolumns(1, 1);
    }
	
	
	void FixedUpdate () {
        AnimatorManager();
        CDManager();
    }
    public void CDManager()
    {
        NormalATKCDTime += Time.deltaTime;
        if (NormalATKCDTime>=2)
        {
            NormalATKCDTime = 2;
        }
        ATKCDTimeA += Time.deltaTime;
        if (ATKCDTimeA >=4)
        {
            ATKCDTimeA = 4;
        }
        ATKCDTimeB += Time.deltaTime;
        if (ATKCDTimeB >=8)
        {
            ATKCDTimeB = 8;
        }
    }
    /// <summary>
    /// 动画控制
    /// </summary>
    public void AnimatorManager()
    {
        if (_rigidbody.velocity.magnitude > 0 && _rigidbody.velocity.magnitude < 0.3f)
        {
            PlayAnimator.SetBool("IsWork", true);
            C_RoleMove.MoveSpeed = 1;
            IsWork = 1;
        }
        else if (_rigidbody.velocity.magnitude > 0.3f)
        {
            PlayAnimator.SetBool("IsRun", true);
            C_RoleMove.MoveSpeed = 3;
            IsRun = 1;
        }
        else
        {
            PlayAnimator.SetBool("IsWork", false);
            PlayAnimator.SetBool("IsRun", false);
            C_RoleMove.MoveSpeed = 1;
            IsWork = 0;
            IsRun = 0;
        }
        AnimatorStateInfo animatorInfo = PlayAnimator.GetCurrentAnimatorStateInfo(0);

        //主角技能J 普通攻击 播放音效 
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (NormalATKCDTime == 2)
            {
                PlayAnimator.SetBool("IsAttack3-2", true);
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                IsNormalAttack = 1;
                NormalATKCDTime = 0;
                AudioClipManager._instance.PlayGameSoundByName("NormalAttack");
               
            }
           
        }
        if ((animatorInfo.normalizedTime >=0.8f) && (animatorInfo.IsName("Attack3-2")))//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
            PlayAnimator.SetBool("IsAttack3-2", false);
            if (animatorInfo.normalizedTime >= 1)
            {
                IsNormalAttack = 0;
            }
      
        }

        //主角技能A
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (ATKCDTimeA == 4)
            {
                PlayAnimator.SetFloat("IsAttack3-1", 1);
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                IsAttackSkillA = 1;
                ATKCDTimeA = 0;
                AudioClipManager._instance.PlayGameSoundByName("AttackSkillA");
                
            }
           
        }

        if ((animatorInfo.normalizedTime >= 0.8f) && (animatorInfo.IsName("Attack3-1")))//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
            PlayAnimator.SetFloat("IsAttack3-1", -1);
            IsAttackSkillA = 0;
      
        }

        //主角技能B
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (ATKCDTimeB == 8)
            {
                PlayAnimator.SetFloat("IsAttack1", 1);
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                IsAttackSkillB = 1;
                ATKCDTimeB = 0;
                AudioClipManager._instance.PlayGameSoundByName("AttackSkillB");
               
            }
           
        }
        if ((animatorInfo.normalizedTime >= 0.8f) && (animatorInfo.IsName("Attack1")))//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
            PlayAnimator.SetFloat("IsAttack1", -1);
            IsAttackSkillB = 0;

        }

    }
    /// <summary>
    /// 发给服务器的动画信息
    /// </summary>
    /// <returns></returns>
    public string EnemyAnimState()
    {
        return "/"+IsWork.ToString() + "/" + IsRun.ToString()+"/"+IsNormalAttack+"/"+IsAttackSkillA
            +"/"+IsAttackSkillB;
    }
}
