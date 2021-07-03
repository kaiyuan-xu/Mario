using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int HP = 1;
    //刚体
    private Rigidbody2D rBody;
    //动画
    private Animator ani;
    //保存方向。方向为1（正方向）和-1（负方向）
    private int dir = -1;


    // Start is called before the first frame update
    void Start()
    {
        //在这里实例得到
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            return;
        }
        //移动（方向*速度）
        //为使敌人碰到物体后向相反方向移动，此处乘以方向（设置了默认正方向
        transform.Translate(Vector2.left * 0.2f * dir * Time.deltaTime);
    }
    //不管碰到什么物体，都向相反方向移动
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dir = -dir;
        //判断玩家碰到自己
        if (collision.collider.tag == "Player")
        {
            //contacts[0]碰撞的点，point代表拿到这一点的位置
            //contacts[0].normal 还有一个法线，就是和碰撞点垂直的单位向量
            //比如玩家从上面踩了敌人，会产生从碰撞点向下的法线
            if (collision.contacts[0].normal == Vector2.down)
            {
                //从上方踩到，敌人死亡
                //拿到玩家身上的刚体组件，给其添加一个向上的力
                collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100f);
                //调用死亡方法
                Die();
            }
            else
            {
                collision.collider.GetComponent<PlayerControl>().Die();
            }
        }

        if(collision.collider.tag == "PlayerPro")
        {
            if (collision.contacts[0].normal == Vector2.down)
            {
                //从上方踩到，敌人死亡
                //拿到玩家身上的刚体组件，给其添加一个向上的力
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
        if (HP <= 0)
        {
            ScenceLoader.score += 400;
            //死亡，一秒后销毁
            Destroy(gameObject, 1f);
            //动画
            ani.SetBool("die", true);
            //声音
            //AudioManager.Instance.PlaySound("踩敌人");
            //使碰撞器失效
            GetComponent<Collider2D>().enabled = false;
            //删除刚体,碰撞器的删除也可采用这种方法
            Destroy(GetComponent<Rigidbody2D>());
        }
    }
}
