﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// enum skeletonstatus
// {
//     ATTACK,
//     DAMAGE,
//     RUN
// }

public class SkeletonController : MonoBehaviour
{

    public GameObject Player;
    public float speed;

    // 0: 可以移動
    // 1: 攻擊狀態
    // 2: 被攻擊中
    int status = 0;
    Animator anim;//動畫控制
    NavMeshAgent navMeshAgent;//導航控制

    //血量
    public GameObject healthBar;
    public float health = 100;
    public float healthmax = 100;
    
    public GameObject blood_FX;
    public GameObject canvas;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
                // 偵測血量
        CheckHealthBar();

        float dist = Vector3.Distance(Player.transform.position, transform.position);
        // print("與其他對象的距離 ;"+ dist);


        if (status != 0)
            return;

        // 如果距離大於 XX 不追
        if (dist > 25)
        {
            anim.SetFloat("Run", 0);
        } 
        // 如果距離小於 XX 追擊
        else if (dist < 25 && dist > 3)
        {
            anim.SetFloat("Run", 0.4f);
            navMeshAgent.SetDestination(Player.transform.position);
        }
        else
        {
            anim.SetBool ("Attack", true);
            status = 1;
        }
    } 

    void AttackEnd()
    {

        anim.SetBool("Attack", false);
        status = 0;
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("OTHER:" + other.tag);
        if(other.tag == "Attack")
        {
            // 觸發受傷事件
            Damage();
        }

        if(other.tag == "Untagged")
        {
            canvas.SetActive(true);
        }
    }  

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Untagged")
        {
            canvas.SetActive(false);
        }
    }
    
    //受傷事件
    void Damage()
    {
        // 如果狀態違背攻擊中 則不往下做
        // if (status == 2)
        //     return;
        //產生怪物受傷特效及音效
        // todo 隨機特效及位置
        Instantiate(blood_FX, new Vector3(transform.position.x,transform.position.y+2f,transform.position.z), transform.rotation);

        health -= 40;
        if (health < 0 && status != 3)
        {
            status = 3;
            anim.SetTrigger("Dead");
            return;
        }

        anim.SetTrigger("Damage");
    }
    void CheckHealthBar()
    {
        healthBar.GetComponent<Transform>().localPosition = new Vector3(  3 - ((3 / healthmax)* health), 0f, 0f);
    }
    void DamageEnd()
    {   
        anim.SetBool("Attack",false);
        anim.SetFloat("Run",0);
        Debug.Log("僵直結束");
        Invoke("ResetStatus",1);
    }

    //reset
    
    void ResetStatus()
    {
        Debug.Log("校正回歸");
        status = 0;
    }
}
