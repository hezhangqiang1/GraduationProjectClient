/*
 * 所属层级：工具层
 * 脚本功能：控制相机的跟随
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform player;    //角色位置信息
    private Vector3 off;        //相机目标点位置信息
    public float speed;         //相机移动速度
    private Quaternion angel;   //相机看向目标的旋转值


    void Start()
    {
        off = player.position - transform.position;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position - off, Time.deltaTime * speed);
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
    }
}
