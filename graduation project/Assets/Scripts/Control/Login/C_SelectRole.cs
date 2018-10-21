/* 所属层级：控制层
 * 脚本功能：选择角色和播放角色动画
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SelectRole : MonoBehaviour
{

    private Animation RoleAnimation;
    public AnimationClip Idle;
   
    void Start()
    {
        RoleAnimation = this.GetComponent<Animation>();
        PlayIdle();
    }

    /// <summary>
    /// 播放Idle动画
    /// </summary>
    public void PlayIdle()
    {
        if (RoleAnimation)
        {
            RoleAnimation.CrossFade(Idle.name);
        }
    }
}  