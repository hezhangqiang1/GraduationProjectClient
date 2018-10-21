/*  
 *  所属层级：控制层
 *  脚本功能：特效的加载，用资源池方法提高游戏性能
 *  (特效较少，暂时弃用)
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{

    public GameObject EffectPrefab;
    private int EffectPrefabCount = 10;//池子容量
    List<GameObject> EffectPrefablist = new List<GameObject>();//池子


    void Start()
    {
        Init();
    }
    /// <summary>
    /// 初始化方法：实例化10个特效作为池子
    /// </summary>
	private void Init()
    {
        for (int i = 0; i <= EffectPrefabCount; i++)
        {
            GameObject go = GameObject.Instantiate(EffectPrefab);
            EffectPrefablist.Add(go);
            go.SetActive(false);
            go.transform.parent = this.transform;
        }
    }
    /// <summary>
    /// 产生特效方法
    /// </summary>
    /// <returns></returns>
    public GameObject GetEffectPrefab()
    {
        foreach (GameObject go in EffectPrefablist)
        {
            if (go.activeInHierarchy == false)
            {
                go.SetActive(true);
                return go;
            }

        }
        return null;
    }


}

