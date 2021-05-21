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
    public int status = 0;
    Animator anim;//動畫控制
    // skeletonstatus skeletonstatus;
    NavMeshAgent navMeshAgent;//導航控制

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log("攻擊結束");
        anim.SetBool("Attack", false);
        status = 0;
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("被盾打到");
    }
}
