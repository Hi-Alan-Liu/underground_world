using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum crabBossStauts
{
    IDLE = 0,//待機
    WALK = 1,//遊走
    ATTACK =2,//追擊目標及攻擊
    RESET =3,//血量回復 走回起點
    DIE =4,//死亡
}
public class CrabBossController : MonoBehaviour
{
    //怪物狀態
    crabBossStauts crabBossStauts;
    float health = 1000;
    [Header("最大生命")]
    public float healthMax = 1000;
    [Header("怪物移動速度")]
    public float speed = 10;
    NavMeshAgent navMeshAgent;//AI導航
    public GameObject target;
    float targetDist;
    bool attack = false;
    [Header("怪物攻擊動畫數量")]
    public int attackMode =0;
    [Header("怪物受傷動畫數量")]
    public int damageMode = 0;
    [Header("怪物待機動畫數量")]
    public int idleMode = 0;
    Animator animator;//怪物動畫
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();
        switch (crabBossStauts)
        {
            case crabBossStauts.IDLE:
                break;
            case crabBossStauts.WALK:
                break;
            case crabBossStauts.ATTACK:
                Attack();
                break;
            case crabBossStauts.RESET:
                break;
            case crabBossStauts.DIE:
                break;
        }
    }
    void CheckTarget()
    {
        targetDist =Vector3.Distance(target.transform.position,transform.position);
        Debug.Log(targetDist);
        if (targetDist < 25 && crabBossStauts != crabBossStauts.ATTACK)
        {
            Debug.Log("怪物進入攻擊狀態");
            crabBossStauts = crabBossStauts.ATTACK;
        }
    }
    void Attack()
    {
        if (attack)
        {
            return;
        }

        if(targetDist > 25)
        {
            animator.SetFloat("Walk", 0);
        }
        else if (targetDist < 25 && targetDist > 5)
        {
            animator.SetFloat("Walk", 1f);
            navMeshAgent.SetDestination(target.transform.position);
        }
        else
        {
            animator.SetFloat("Walk", 0);
            animator.SetBool("Attack",true);
            int randomNumber = Random.Range(1,attackMode);
            animator.SetInteger("AttackMode",randomNumber);
        }
    }
    void AttackEnd()
    {
        animator.SetBool("Attack", false);
        attack = false;
    }
    
}
