using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_Four : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //判断玩家碰到自己
        if (collision.tag == "Player" || collision.tag == "PlayerPro")
        {
            ScenceLoader.isWorld1 = true;
        }
    }
}
