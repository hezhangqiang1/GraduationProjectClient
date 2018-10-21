/*
 * 所属层级：工具层
 * 脚本功能：公共字段和公共方法
 * 
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globe
{
    public static string nextSceneName;


    /// <summary>
    /// 分割字符串
    /// </summary>
    /// <param name="s">要分割的字符串</param>
    /// <param name="c">分割条件</param>
    /// <returns></returns>
    public static string[] StringSplit(string s, string c)
    {
        string[] strArr = s.Split(Convert.ToChar(c));
        return strArr;
    }

  

}
