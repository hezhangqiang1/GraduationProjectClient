/* 所属层级：控制层
 * 脚本功能：控制主角移动
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RoleMove : MonoBehaviour
{

    //public AnimationClip idle;
    //public AnimationClip work;
    //public AnimationClip Attack_H;
    //public AnimationClip Attack_J;
    //public AnimationClip Attack_K;
    //public Animation _animation;

    public static float MoveSpeed=1;
    
    public float h = 0.0f;
    public float v = 0.0f;

    private  Animator Playanimator;
    public Rigidbody _rigidbody;
    //private CharacterController charController = null;

    #region 本类实例
    public static C_RoleMove instance;
    public static C_RoleMove GetInstance
    {
        get
        {
            if (instance == null)
            {
                return new C_RoleMove();
            }
            return instance;
        }
        set
        {

        }
    }
    #endregion
    void Start()
    {
        //_animation = GetComponentInChildren<Animation>();
         _rigidbody = GetComponent<Rigidbody>();
        Playanimator = GetComponent<Animator>();
        //charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        AnimatorStateInfo animatorInfo = Playanimator.GetCurrentAnimatorStateInfo(0);
        if (C_PlayerAnim.IsNormalAttack==0&&C_PlayerAnim.IsAttackSkillA==0&&C_PlayerAnim.IsAttackSkillB==0)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            Vector3 Vec = _rigidbody.velocity;
            _rigidbody.velocity = new Vector3(h * MoveSpeed, Vec.y, v * MoveSpeed);
            //if (h != 0 && v != 0)
            //{
            //    charController.SimpleMove(transform.forward *v*MoveSpeed);
            //}


            if ((Mathf.Abs(h) > 0.05 || Mathf.Abs(v) > 0.05) && Playanimator.GetFloat("IsAttack1") <= 0)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v));
            }

        }



        #region
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    Debug.Log("HHHHHHHH");
        //    _animation.CrossFade(Attack_H.name);
        //}
        //else if (Input.GetKeyDown(KeyCode.J))
        //{
        //    _animation.CrossFade(Attack_J.name);
        //    Debug.Log("jjjjjjjjj");
        //}
        //else if (Input.GetKeyDown(KeyCode.K))
        //{
        //    _animation.CrossFade(Attack_K.name);
        //    Debug.Log("kkkkkkkkk");
        //}
        //if (v >= 0.1f)
        //{
        //    _animation.CrossFade(work.name);
        //    transform.Translate(Vector3.forward * Time.deltaTime *MoveSpeed,Space.Self);
        //}
        //else if (v <= -0.1f)
        //{
        //    _animation.CrossFade(work.name);
        //    transform.Translate(Vector3.back * Time.deltaTime*MoveSpeed, Space.Self);
        //}
        //else if (h >= 0.1f)
        //{
        //    _animation.CrossFade(work.name);
        //    transform.Rotate(Vector3.up, RotateValue);
        //}
        //else if (h <= -0.1f)
        //{
        //    _animation.CrossFade(work.name);
        //    transform.Rotate(Vector3.down, RotateValue);
        //}

        //else
        //{
        //    _animation.CrossFade(idle.name);
        //}
        #endregion
    }
}

