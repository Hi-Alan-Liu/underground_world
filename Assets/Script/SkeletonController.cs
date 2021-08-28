﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum skeletonStatus
{
    IDEL = 0, // 待機
    WALK = 1, // 遊走
    ATTACK = 2, // 當進入視線範圍時 怒吼 | 當進入攻擊範圍時 追擊+攻擊
    RESET = 3, // 血量回復 + 走回起始點
    Death = 4 // 死亡
}

public class SkeletonController : MonoBehaviour
{
    skeletonStatus skeletonStatus; // 怪物狀態
    public GameObject player; // 主角
    public float speed; // 移動速度

    // 是否攻擊
    bool attack = false;
    Animator anim;// 動畫控制
    NavMeshAgent navMeshAgent;// 導航控制

    //血量
    public GameObject healthBar;
    public float health = 100;
    public float healthmax = 100;
    
    public GameObject blood_FX;
    public GameObject canvas;
    int status = 0;
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
        dist = Vector3.Distance(player.transform.position,transform.position);
        if(dist<35)
        {
            anim.SetTrigger("Skill");
            skeletonStatus = skeletonStatus.ATTACK;
        }

        switch (skeletonStatus)
        {
            // 待機事件
            case skeletonStatus.IDEL:
                break;
            // 遊走事件
            case skeletonStatus.WALK:
                break;
            // 攻擊事件
            case skeletonStatus.ATTACK:
                AttackEvent();
                break;
            // 初始化
            case skeletonStatus.RESET:
                break;
        }
    } 
    // 
    void AttackEvent()
    {
        // 計算主角與怪物的距離
        float dist = Vector3.Distance(player.transform.position, transform.position);
        // print("與其他對象的距離 ;"+ dist);

        // 如果距離大於 XX 不追
        if (dist > 25)
        {
            anim.SetFloat("Run", 0);
        } 
        // 如果距離小於 XX 追擊
        else if (dist < 25 && dist > 3)
        {
            anim.SetFloat("Run", 0.4f);
            navMeshAgent.SetDestination(player.transform.position);
        }
        else
        {
            anim.SetBool ("Attack", true);
            attack = true;
        }
    }
    void AttackEnd()
    {

        anim.SetBool("Attack", false);
        attack = false;
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
