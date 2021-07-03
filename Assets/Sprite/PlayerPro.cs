using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPro : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rBody;
    private SpriteRenderer sr;
    public bool isGround = false;
    public GameObject SMario;



    // Start is called before the first frame update
    void Start()
    {//实例化组件
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //Debug.Log(PlayerControl.hp); 
    }

    // Update is called once per frame
    void Update()
    {
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
            ani.SetBool("Run", true);
        }
        else
        {
            ani.SetBool("Run", false);
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
            ani.SetBool("Jump", true);
        }
        else
        {
            //没碰到地面（在空中）
            isGround = false;
            ani.SetBool("Jump", false);
        }
    }
    public void Die()
    {
        //Debug.Log(PlayerControl.HP);
        //PlayerControl.HP--;
        //Debug.Log(PlayerControl.HP);
        //GameObject.Find("Mario").GetComponent<PlayerControl>().ShowM();
        //GameObject.Find("MainCamera").GetComponent<CameraControl>().enabled=false;
        Instantiate(SMario, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

