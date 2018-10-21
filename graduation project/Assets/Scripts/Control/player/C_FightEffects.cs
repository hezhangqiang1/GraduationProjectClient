/*
 * 所属层级：控制层 
 * 脚本功能：播放特效
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_FightEffects : MonoBehaviour {
    public GameObject NormalATKEffect;
    public GameObject AttackSkillEffectA;
    public GameObject AttackSkillEffectB;

    public Vector3 EffectPosition;

    void Update()
    {
        EffectPosition = transform.position + transform.forward * 2;
    }
    
        /// <summary>
        /// 普通攻击的动画帧事件
        /// </summary>
    public void NormalAttackEffectEvent()
    {
        GameObject.Instantiate(NormalATKEffect, EffectPosition, Quaternion.identity);
    }
    /// <summary>
    /// 技能A的动画帧事件
    /// </summary>
    public void AttackSkillEffectAEvent()
    {
        GameObject.Instantiate(AttackSkillEffectA, EffectPosition, Quaternion.identity);
    }
    /// <summary>
    /// 技能B的动画帧事件
    /// </summary>
    public void AttackSkillEffectBEvent()
    {
        GameObject.Instantiate(AttackSkillEffectB, EffectPosition, Quaternion.identity);
    }   
       
}
