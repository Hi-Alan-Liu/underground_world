using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    // 3: 角色死亡
    public int status = 0;
    public bool attacking = false;

    //血量與魔力
    public GameObject healthBar;
    public GameObject manaBar;
    public float health = 100;
    public float mana = 100;
    public float healthmax = 100;
    public float manamax = 100;
    public GameObject healthText;
    public GameObject manaText;
    public BoxCollider weapon;
    public GameObject Torch_01_Variation;
    public GameObject Torch_02_Variation;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move ();
        Attack();
        CheckHealthBar ();
    }

    void Move ()
    {

        if (status != 0) 
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("V", v);
        anim.SetFloat("H", h);
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            anim.SetBool("Move", true);
        } else
        {
            anim.SetBool("Move", false);
        }

        //如果玩家只按前進按鈕時，玩家前進方向跟隨鏡頭
        if(v > 0.1f && h == 0) {
            Vector3 direction = new Vector3(h, 0f, v).normalized;
            //腳色對面攝影機方向轉
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Debug.Log(targetAngle);
            //腳色旋轉優化
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //控制腳色旋轉
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        //計算移動位置
        velocity = new Vector3(h, 0, v);
        velocity = transform.TransformDirection(velocity);

        if (v > 0.1f)
        {
            velocity *= speed;
        } else if(v > -0.1f && h != 0f){
            velocity *= (speed * 0.7f);
        }

        //把計算好的位置加到角色
        transform.localPosition += velocity * Time.fixedDeltaTime;
        //角色旋轉
        //transform.Rotate(0, h * rotateSpeed, 0);
    }
    void Attack()
    {
        if (attacking)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
            anim.SetInteger("AttackType",0);
            status = 1;
        }

        if(Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("Attack");
            anim.SetInteger("AttackType",1);
            status = 1;
        }
        if (status == 1)
        {
            weapon.enabled = true;
        } else
        {
            weapon.enabled = false;
        }
    }
    void AttackStart()
    {
        attacking = true;
        Debug.Log("攻擊開始:" + anim.GetInteger("AttackType"));
        GameObject gameObject = anim.GetInteger("AttackType") == 0 ? Torch_01_Variation : Torch_02_Variation;
        Instantiate(gameObject, new Vector3(transform.position.x,transform.position.y+2f,transform.position.z),transform.rotation);
    }
    void AttackCombo()
    {
        attacking = false;
        Debug.Log("attacking = false");
    }
    void AttackEnd()
    {
        anim.SetBool("Attack", false);
        status = 0;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Attack01")
        {
            Damage();
        }
    }

    void Damage()
    {
        if(status == 2 || status == 3)
            return;

        health -= 10;
        if (health <= 0 && status != 3) 
        {
            status = 3;
            anim.SetTrigger("Dead");
            return;
        }

        anim.SetTrigger("Damage");
    }

    void CheckHealthBar()
    {
        healthText.GetComponent<Text>().text = health + "/" + healthmax;
        healthBar.GetComponent<Transform>().localPosition = new Vector3( - 175 + ((175 / healthmax)* health), 0f, 0f);

    }
    void DeadEnd()
    {   
        anim.SetBool("Attack",false);
        anim.SetFloat("Speed",0);
        attacking = false;
        Debug.Log("玩家僵直結束");
        Invoke("ResetStatus",1);
    }

    void ResetStatus()
    {
        status = 0;
    }

}
