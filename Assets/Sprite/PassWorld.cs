using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWorld : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //判断玩家碰到自己
        if (collision.tag == "Player")
        {
            ScenceLoader.Pa1 = true;
        }
    }
}
