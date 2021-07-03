using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    //血量。（顶几次）
    public int Hp = 5;
    //顶出来的物体
    public GameObject goPre;
    //音效名称（传进来）
    //public string sound;

    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果玩家从下面顶撞
        if (collision.collider.tag == "Player" && collision.contacts[0].normal == Vector2.up|| collision.collider.tag == "PlayerPro"&&collision.contacts[0].normal == Vector2.up)
        {
            if (Hp > 0)
            {
                Hp--;
                //顶出物品
                //声音
                //AudioManager.Instance.PlaySound(sound);
                //实例化物品
                Instantiate(goPre, transform.position, Quaternion.identity);
                if (Hp <= 0)
                {
                    //变成砖块（就是下面的“没了”）
                    //获得动画
                    GetComponent<Animator>().SetTrigger("die");
                }
            }
            else
            {
                //箱子已经没了。
                //播放没了的声音
                //AudioManager.Instance.PlaySound("顶砖石块");
            }
        }
        //if (collision.collider.tag == "PlayerPro" && collision.contacts[0].normal == Vector2.up)
        //{
        //    if (Hp > 0)
        //    {
        //        Hp--;
        //        //顶出物品
        //        //声音
        //        //AudioManager.Instance.PlaySound(sound);
        //        //实例化物品
        //        Instantiate(goPre, transform.position, Quaternion.identity);
        //        if (Hp <= 0)
        //        {
        //            //变成砖块（就是下面的“没了”）
        //            //获得动画
        //            GetComponent<Animator>().SetTrigger("die");
        //        }
        //    }
        //    else
        //    {
        //        //箱子已经没了。
        //        //播放没了的声音
        //        //AudioManager.Instance.PlaySound("顶砖石块");
        //    }
        //}
    }
}
