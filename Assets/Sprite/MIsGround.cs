using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIsGround : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool Ground = collision.GetComponent<MDaohang>().isGround;
        bool Swim = collision.GetComponent<MDaohang>().swim;
        //判断玩家碰到自己
        if (collision.tag == "Player")
        {
            if(Ground==true)
            {
                collision.GetComponent<MDaohang>().isGround = false;
                collision.GetComponent<MDaohang>().swim = false;
            }
            if(Ground==false)
            {
                collision.GetComponent<MDaohang>().isGround = true;
                collision.GetComponent<MDaohang>().swim = false;
            }
        }
    }
}
