using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //判断玩家碰到自己
        if (collision.tag == "Player"||collision.tag=="PlayerPro")
        {
            //玩家碰到敌人，玩家死亡
            collision.GetComponent<PlayerControl>().Die();
        }
    }
}
