/*  
 *   所属层级：工具层
 *   脚本功能：管理游戏中音效的播放和声音的调节
 *   audioSourceBG是背景（2D）音乐，挂在相机上即可
 *   gamesound是游戏音效（3D）挂在人物角色身上
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager : MonoBehaviour
{
    public static AudioClipManager _instance;
    public static Dictionary<string, AudioClip> DicAudioClipLib;   //音频库
    public static float AudioClipVolumns = 1F;                     //背景音量
    public static float GameSoundVolumns = 1f;                     //游戏音效音量

    private AudioSource audioSourceBG;                             //背景音乐
    private AudioSource gamesound;                                 //游戏音效

    private GameObject AudioSourceBG;                                       
    private GameObject AudioSourceGO;
  


    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);

        AudioSourceBG = new GameObject("AudioSourceBG");
       
        AudioSourceGO = new GameObject("AudioSourceGO");

        audioSourceBG = AudioSourceBG.AddComponent<AudioSource>();

        gamesound = AudioSourceGO.AddComponent<AudioSource>();
        gamesound.spatialBlend = 1;//设置成3D音效

        DicAudioClipLib = new Dictionary<string, AudioClip>();
        
        if (PlayerPrefs.GetFloat("BGVolumns") >= 0)
        {
            AudioClipVolumns = PlayerPrefs.GetFloat("BGVolumns");
            audioSourceBG.volume = AudioClipVolumns;
        }
       
    }
    /// <summary>
    /// 播放背景音效（2D）
    /// </summary>
    /// <param name="name">音效名字</param>
    public void PlayAudioSourceBGByName(string name)
    {
        AudioClip clip;
        if (DicAudioClipLib.TryGetValue(name, out clip))
        {
            PlaySound(clip, audioSourceBG);
        }
        else
        {
            clip = Resources.Load<AudioClip>("Sounds/" + name);
            PlaySound(clip, audioSourceBG);
            DicAudioClipLib.Add(name, clip);

        }
    }
    /// <summary>
    /// 播放游戏音效（3D）
    /// </summary>
    /// <param name="name">音效名字</param>
	public void PlayGameSoundByName(string name)
    {
        AudioClip clip;
        if (DicAudioClipLib.TryGetValue(name, out clip))
        {
            PlaySound(clip, gamesound);
        }
        else
        {
            clip = Resources.Load<AudioClip>("Sounds/" + name);
            PlaySound(clip, gamesound);
            DicAudioClipLib.Add(name, clip);

        }
    }
    /// <summary>
    /// 停止播放音效
    /// </summary>
    public void StopPlayBGSound()
    {
       audioSourceBG.Stop();
    }

    /// <summary>
    /// 改变音乐音量
    /// </summary>
    /// <param name="floAudioBGVolumns">背景音乐音量</param>
    /// <param name="floGameSoundVolum">游戏音效音量</param>
    public void SetAudioVolumns(float floAudioBGVolumns, float floGameSoundVolum)
    {
        audioSourceBG.volume = floAudioBGVolumns;
        gamesound.volume = floGameSoundVolum;
        AudioClipVolumns = floAudioBGVolumns;
        GameSoundVolumns = floGameSoundVolum;

        PlayerPrefs.SetFloat("BGVolumns", floAudioBGVolumns);
        PlayerPrefs.SetFloat("GameSoundVolumns", floGameSoundVolum);
    }
    /// <summary>
    /// 播放声音的抽象方法
    /// </summary>
    /// <param name="clip">音乐剪辑</param>
    /// <param name="source">播放器</param>
    private void PlaySound(AudioClip clip, AudioSource source)
    {
        if (clip != null && !source.isPlaying)
        {
            source.clip = clip;
            source.Play();
        }
    }
}
