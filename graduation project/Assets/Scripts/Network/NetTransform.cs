/*
 * 所属层级：网络层 
 * 脚本功能：向服务器同步自己的位置信息
 * 
 */


using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class NetTransform : MonoBehaviour {

    private float x;
    private float y;
    private float z;
  
    private float ry;
    public int PlayerID;
   

   
    void Start()
    {

    }
	
	void Update () {

       
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        Vector3 rotation = transform.localEulerAngles;
        ry = rotation.y;
        

    }
    /// <summary>
    /// 位置信息转化为字符串
    /// </summary>
    /// <returns></returns>
    public string Transformtobyte()
    {
        string str = "Pos/" + x.ToString() + "/" + y.ToString() + "/" + z.ToString() + "/" + ry.ToString();
        return str;

    }

}
