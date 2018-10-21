/* 
 * 脚本UI显示工具类
 * 用来作经验计算等算法
 * 
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShowTool : MonoBehaviour {
    public static UIShowTool Instance;//本类实例
	
    void Awake()
    {
        Instance = this;
    }
	void Start () {
		
	}
	void Update () {
		
	}
    //经验的计算公式
    public int CalculateExperience(int Level)
    {
        return Level * 10;
    }
}
