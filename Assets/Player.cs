using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    ///宣告變數
    public float speed = 5;//角色移動速度
    public float rotateSpeed = 5;
    Vector3 velocity;//儲存角色位置

    //儲存動畫
    Animator anim;

    // 0: 可以移動
    // 1: 攻擊狀態
    // 2: 被攻擊中
    public int status = 0;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        Debug.Log(Checkd(11));
    }

    // Update is called once per frame
    void Update()
    {
        Move ();
    }

    void Move ()
    {

        if (status != 0) 
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Debug.Log("左右數值" + h);
        // Debug.Log("左右數值" + v);
        //計算移動位置
        velocity = new Vector3(0, 0, v);
        velocity = transform.TransformDirection(velocity);
        
        anim.SetFloat("Speed", v);
        if (v > 0.1)
        {
            //移動位置乘上速度
            velocity *= speed;
        }

        //把計算好的位置加到角色
        transform.localPosition += velocity * Time.fixedDeltaTime;
        //角色旋轉
        transform.Rotate(0, h * rotateSpeed, 0);
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);
            status = 1;
        }
    }

    string Checkd(int cs) 
    {
        if (cs> 10)
        {
            return "完美";
        }
        else
        {
            return "不完美";
        }
    }

    void AttackEnd()
    {
        anim.SetBool("Attack", false);
        status = 0;
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("測試碰撞");
        if(other.tag == "Attack01")
        {
        Debug.Log("被怪物攻擊");
        anim.SetTrigger("Dead");
        }
    }

    void DeadEnd()
    {   
        anim.SetBool("Attack",false);
        anim.SetFloat("Speed",0);
        Debug.Log("玩家僵直結束");
        Invoke("ResetStatus",1);
    }

    void ResetStatus()
    {
        Debug.Log("玩家校正回歸");
        status = 0;
    }

}
