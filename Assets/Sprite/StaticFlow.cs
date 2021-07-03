using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFlow : MonoBehaviour
{
    public int HP = 1;
    //刚体
    private Rigidbody2D rBody;
    //动画
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        //在这里实例得到
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            ScenceLoader.score += 200;
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //判断玩家碰到自己
        if (collision.collider.tag == "Player")
        {
                //玩家碰到敌人，玩家死亡
                collision.collider.GetComponent<PlayerControl>().Die();
        }
        if (collision.collider.tag == "PlayerPro")
        {
            //玩家碰到敌人，玩家死亡
            collision.collider.GetComponent<PlayerPro>().Die();
        }
    }
}
