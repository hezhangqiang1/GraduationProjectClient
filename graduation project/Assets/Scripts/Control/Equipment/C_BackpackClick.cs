/*   所属层级：控制层
 *   脚本功能：背包按钮的点击
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_BackpackClick : MonoBehaviour {

    public GameObject BackpackPanel;//背包的显示




    /// <summary>
    /// 背包的点击事件
    /// </summary>
    public void BackPackClick()
    {
        BackpackPanel.SetActive(true);
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");

    }
    /// <summary>
    /// 背包的退出点击事件
    /// </summary>
    public void ExitBackpackClick()
    {
        BackpackPanel.SetActive(false );
        AudioClipManager._instance.PlayGameSoundByName("ButtonClickE");
    }
}
