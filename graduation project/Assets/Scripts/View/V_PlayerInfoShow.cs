/*  UI显示层拿到了UI的控件
 *  更新UI的显示
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class V_PlayerInfoShow : MonoBehaviour {

#region   UI控件
    public Text PlayerName;//用户名
    public Text Experience;//等级
    public Text TotalStrength;//总体力
    public Text CurrentStrength;//当前体力
    public Text TotalExp;//总历练
    public Text CurrentExp;//当前历练
    public Text DiamondNum;//钻石数量
    public Text GoldNum;//金币数量

    public Text InfoPlayerName;//信息板用户名
    public Text InfoPower;//战斗力
    public Text InfoExperience;//等级
    public Text InfoTotalExp;//总经验值
    public Text InfoCurrentExp;//当前经验值
    public Text InfoDiamond;//钻石数
    public Text InfoGold;//金币数
    public Text InfoStone;//晶石数
    public Text InfoIron;//陨铁数
    public Text InfoStrength;//体力
    public Text InfoExp;//历练
    public Text InfoStrengthTime;//体力恢复时间
    public Text InfoExpTime;//体力恢复时间

    public Slider SliStrength;//体力血条
    public Slider SliExp;//历练血条
    public Slider SliExpenience;//经验血条
    #endregion
    public M_PlayerInfo Info;


    void Start()
    {
        PlayerName.text = C_StartMenu.PlayerName;
        Info.ChangeInfo += PlayerInfoChange;
        
    }
   void OnDestroy()
    {
        Info.ChangeInfo -= PlayerInfoChange;
    }
    /// <summary>
    /// 主角信息更改
    /// </summary>
    /// <param name="date"></param>
    void PlayerInfoChange(M_PlayerInfo.DataType date)
    {
         if(date ==M_PlayerInfo.DataType.All||date==M_PlayerInfo.DataType .DiamondNum||date==M_PlayerInfo.DataType.Experience
              ||date ==M_PlayerInfo.DataType .ExpNum||date==M_PlayerInfo.DataType.GoldNum||date==M_PlayerInfo.DataType.Head||
                 date == M_PlayerInfo.DataType.Level || date == M_PlayerInfo.DataType.Name || date == M_PlayerInfo.DataType.Power || date == M_PlayerInfo.DataType.StrengthNum)
         {
            UpdateShow();

         }
    }
    /// <summary>
    /// 更新UI显示
    /// </summary>
    void UpdateShow()
    {
       // M_PlayerInfo Info = M_PlayerInfo._instance;
       PlayerName.text = Info.Name;
        CurrentExp.text = Info.ExpNum.ToString();
        CurrentStrength.text = Info.StrengthNum.ToString();
        InfoCurrentExp.text = Info.Experience.ToString();
        Experience.text = Info.Level.ToString ();
        InfoPower.text = Info.Power.ToString();
        //DiamondNum.text =Info.DiamondNum.ToString();
        GoldNum.text = Info.GoldNum.ToString();

        SliExpenience.value = Info.Experience / 300f;
        SliStrength.value = Info.StrengthNum / 100f;
        SliExp.value = Info.ExpNum / 100f;

        // InfoDiamond.text = "钻石："+ Info.DiamondNum.ToString();
        InfoGold.text ="金币："+ Info.GoldNum.ToString ();
        InfoExperience.text = Info.Level.ToString();
        //  InfoStrength.text = "体力："+Info.StrengthNum.ToString()+"/100";
        //  InfoExp.text = "历练：" + Info.ExpNum.ToString() + "/100";
        InfoPlayerName.text = Info.Name;
        InfoTotalExp.text ="/"+ Info.MaxExpenience.ToString();

    }


}
