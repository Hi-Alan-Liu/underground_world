using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum monsterStauts
{
    IDLE = 0,//待機
    WALK = 1,//遊走
    ATTACK =2,//追擊目標及攻擊
    RESET =3,//血量回復 走回起點
    DAMAGE =4,//死亡
}
public class monsterController : MonoBehaviour
{
    //怪物狀態
    monsterStauts monsterStauts;
    public float health;
    [Header("最大生命")]
    public float healthMax;
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
    int status = 0;
    bool idle = false;
    bool die = false;
    bool damege = false;
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
        targetDist =Vector3.Distance(target.transform.position,transform.position);
        if(die || damege)
            return;

        switch (monsterStauts)
        {
            case monsterStauts.IDLE:
                IdleEvent();
                break;
            case monsterStauts.WALK:
                CheckTarget();
                break;
            case monsterStauts.ATTACK:
                Attack();
                break;
            case monsterStauts.RESET:
                break;
            case monsterStauts.DAMAGE:
                Damage();
                break;
        }
    }
    void CheckTarget()
    {
        targetDist =Vector3.Distance(target.transform.position,transform.position);
        if (targetDist < 25 && monsterStauts != monsterStauts.ATTACK)
        {
            monsterStauts = monsterStauts.ATTACK;
        }
        else if(targetDist >= 25 && monsterStauts != monsterStauts.IDLE)
        {
            Debug.Log("怪物進入待機狀態");
            animator.SetFloat("Walk", 0);
            navMeshAgent.SetDestination(transform.position);
            monsterStauts = monsterStauts.IDLE;
        }
    }
    void IdleEvent()
    {
        if (idle)
            return;

        int randomNumber = Random.Range(0, idleMode);

        if (randomNumber !=0)
        {
            animator.SetBool("Idle", true);
            animator.SetInteger("IdleMode",randomNumber);
            idle = true;
        }
        else
        {
            monsterStauts = monsterStauts.WALK;
        }
    }
    void IdleEnd()
    {
        animator.SetBool("Idle", false);
        idle = false;
    }
    void WalkEvet()
    {

    }
    void Attack()
    {
        if (attack)
        {
            return;
        }

        if(targetDist > 24)
        {
            animator.SetFloat("Walk", 0);
            animator.SetBool("Attack",false);
            attack = false;
            monsterStauts = monsterStauts.WALK;
        }
        else if (targetDist < 24 && targetDist > 3)
        {
            animator.SetFloat("Walk", 1f);
            navMeshAgent.SetDestination(target.transform.position);
        }
        else
        {
            attack = true;
            navMeshAgent.SetDestination(transform.position);
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
        monsterStauts = monsterStauts.WALK;
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Attack")
        {
            // 狀態改變受傷
            monsterStauts = monsterStauts.DAMAGE;
        }


    }  
    void Damage()
    {
        if (attack || die)
        {
        attack= false;
        idle = false;
        }

        health -= 40;
        if (health < 0 && die == false)
        {
            die = true;
            animator.SetTrigger("Die");
            Invoke("Destroy", 5);
            return;
        }
        int randomNumber = Random.Range(1, damageMode);
        if (randomNumber !=0)
        {
            ComboComtroller._instance.combostart();
            animator.SetTrigger("Damage");
            animator.SetInteger("DamageMode",randomNumber);
            damege = true;
        }
    }
        void DamageEnd()
    {   
        damege = false;
        monsterStauts = monsterStauts.IDLE;
    }
        void Destroy()
    {
        Destroy(this.gameObject);
    }
}
