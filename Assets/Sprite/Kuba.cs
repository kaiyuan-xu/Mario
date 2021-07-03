using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuba : MonoBehaviour
{
    public static int HP = 30;
    //private int i = 0;
    private bool jump = false;
    private bool attack = false;
    private bool run = false;
    private bool A;
    private bool B;
    private float actRestTime = 1.5f;
    private float LastActTime;
    public float[] actionWeight = { 3000, 3000, 4000 };
    private float dis;
    private float pos;

    private Rigidbody2D rBody;
    private SpriteRenderer sr;

    public GameObject Firek;
    private Transform targets;//获取马里奥的位置
    public Transform Din;

    private enum State
    {
        STAND,
        ATTACK,
        JUMP
    }
    private State cState = State.STAND;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        RandomAction();
    }

    private void RandomAction()
    {
        LastActTime = Time.time;
        float number = Random.Range(0, actionWeight[0] + actionWeight[1] + actionWeight[2]);
        if (number <= actionWeight[0])
        {
            cState = State.STAND;
        }
        else if (actionWeight[0] < number && number <= actionWeight[0] + actionWeight[1])
        {
            cState = State.ATTACK;
        }
        if (actionWeight[0] + actionWeight[1] < number && number <= actionWeight[0] + actionWeight[1] + actionWeight[2])
        {
            cState = State.JUMP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dis = (transform.position - Din.position).sqrMagnitude;
        if (HP <= 0)
        {
            return;
        }
        switch (cState)
        {
            case State.STAND:
                if (Time.time - LastActTime > actRestTime)
                {
                    RandomAction();
                    run = false;
                }
                Run_Dlw();
                break;
            case State.JUMP:
                if (Time.time - LastActTime > 3)
                {
                    RandomAction();
                    jump = false;
                }
                Jump_Dlw();
                break;
            case State.ATTACK:
                if (Time.time - LastActTime > actRestTime)
                {
                    RandomAction();
                    attack = false;
                }
                Attack_Dlw();
                break;
        }
        if (PlayerControl.HP == 1)
        {
            if (!A)
            {
                Position();
                B = true;
                A = true;
            }
            Look();
        }
        else if (PlayerControl.HP == 2)
        {
            if (B)
            {
                Position();
                A = false;
                B = false;
            }
            Look();
        }
    }
    //void FixedUpdate()
    //{

    //}
    private void Position()
    {
        if (PlayerControl.HP == 1)
        {
            targets = GameObject.FindWithTag("Player").transform;
        }
        if (PlayerControl.HP == 2)
        {
            targets = GameObject.FindWithTag("PlayerPro").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (collision.contacts[0].normal == Vector2.down)
            {
                //从上方踩到，敌人死亡
                collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100f);
                //调用死亡方法
                Die();
            }
            else
            {
                collision.collider.GetComponent<PlayerControl>().Die();
            }
        }

        if (collision.collider.tag == "PlayerPro")
        {
            if (collision.contacts[0].normal == Vector2.down)
            {
                //从上方踩到，敌人死亡
                collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100f);
                //调用死亡方法
                Die();
            }
            else
            {
                collision.collider.GetComponent<PlayerPro>().Die();
                //collision.collider.GetComponent<PlayerControl>().Die3();
            }
        }
    }
    void Die()
    {
        HP--;
        if (HP <= 0||ScenceLoader.Win==true)
        {
            ScenceLoader.score += 1000;
            //死亡，一秒后销毁
            Destroy(gameObject, 0.2f);
            //动画
            //ani.SetBool("die", true);
            //声音
            //AudioManager.Instance.PlaySound("踩敌人");
            //使碰撞器失效
            GetComponent<Collider2D>().enabled = false;
            //删除刚体,碰撞器的删除也可采用这种方法
            Destroy(GetComponent<Rigidbody2D>());
        }
    }
    private void Attack_Dlw()
    {
        if (attack == false)
        {
            Instantiate(Firek, transform.position, Quaternion.identity);
            attack = true;
        }
    }

    private void Jump_Dlw()
    {
        if (jump == false)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150f);
            jump = true;
        }
    }
    private void Run_Dlw()
    {
        if (run == false)
        {
            run = true;
        }
    }
    private void Look()
    {
        pos = (targets.transform.position - Din.position).sqrMagnitude;
        if (pos > dis)
        { sr.flipX = true; Fire.Rota = true; }
        else if (pos < dis)
        { sr.flipX = false; Fire.Rota = false; }
    }
}

