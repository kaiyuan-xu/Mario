using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rBody;
    private SpriteRenderer sr;
    public bool isGround = false;
    //public bool isDefeat;
    public static int HP = 1;
    //public int hp = 1;
    public GameObject ProM;
    public GameObject SMario;

    void Start()
    {//实例化组件
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //Debug.Log(PlayerControl.HP);
    }

    // Update is called once per frame
    void Update()
    {
        //if(HP==1)
        //{
        //    gameObject.SetActive(true);
        //    Debug.Log(PlayerControl.HP);
        //}
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)//移动
        {//根据按键来进行水平移动与反转人物朝向
            transform.Translate(transform.right * 1 * Time.deltaTime * horizontal);//由移动，方向，速度组成
            if (horizontal < 0)
            {
                sr.flipX = true;
            }
            if (horizontal > 0)
            {
                sr.flipX = false;
            }
            ani.SetBool("run", true);
        }
        else
        {
            ani.SetBool("run", false);
        }
        //跳跃
        if (Input.GetKeyDown(KeyCode.K) && isGround == false)
        {
            //跳跃力（向上，作用在刚体上）
            rBody.AddForce(Vector2.up * 200);
            //播放跳的声音
            //AudioManager.Instance.PlaySound("跳");
        }
        //画出射线，从中心点出发，向下0.1米
        Debug.DrawRay(transform.position, Vector2.down * 0.1f);
        //创建2d射线，特点：可以直接返回，3d返回的是布尔值，hit在上面，利用
        //out给hit值。而且在括号里可以直接填写射线的起点，方向，距离，检测的层
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, 1 << 8);
        if (hit.collider != null)
        {
            //说明碰到地面了
            isGround = true;
            //吧跳跃的动画关闭
            ani.SetBool("jump", true);
        }
        else
        {
            //没碰到地面（在空中）
            isGround = false;
            ani.SetBool("jump", false);
        } 
    }
    public void Die()
    {
        HP--;
        if (HP <= 0)
        {
            //Invoke("Show", 2f);
            //删除碰撞器(因为玩家死亡时，是掉落状态)
            Destroy(GetComponent<Collider2D>());
            //死亡
            ani.SetTrigger("die");
            
            //停止播放背景音乐
            //AudioManager.Instance.StopMusic();
            //播放死亡音乐
            //AudioManager.Instance.PlaySound("死亡1");
            //让玩家静止
            rBody.velocity = Vector2.zero;
            //让玩家静止，就是将他的速度设为0，为了避免玩家在不同情况下死亡后，向上跳的高度不同
            rBody.velocity = Vector2.zero;
            //死亡跳跃，给出一个向上的力
            rBody.AddForce(Vector2.up * 150f);
            //延时，一秒之后播放音乐
            //Invoke("Die2", 1f);
        }
    }
    //void Die2()
    //{
    //    AudioManager.Instance.PlaySound("死亡2");
    //}

    public void Pro()
    {
        HP++;
        //hp = HP;
        if(HP == 2)
        {
            //gameObject.SetActive(false);
            Instantiate(ProM,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void Die3()
    {
        //gameObject.SetActive(true);
    }
}

