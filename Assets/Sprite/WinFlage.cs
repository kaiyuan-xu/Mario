using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlage : MonoBehaviour
{
    //private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        //ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //判断玩家碰到自己
        if (collision.tag == "Player" || collision.tag == "PlayerPro")
        {
            ScenceLoader.Win = true;
        }
    }
}
