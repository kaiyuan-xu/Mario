using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockA : MonoBehaviour
{
    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果玩家碰了我，并且碰撞点的法线向上（说明玩家是从线面碰到的）
        if (collision.collider.tag == "PlayerPro" && collision.contacts[0].normal == Vector2.up)
        {
            //播放音乐
            //AudioManager.Instance.PlaySound("顶破砖");
            ani.SetBool("Brock", true);
            //销毁大砖块
            Destroy(gameObject, 0.5f);
        }
    }
}

