using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateComtrol : MonoBehaviour
{
    public GameObject goPre; 
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
            Instantiate(goPre, transform.position, Quaternion.identity);
        }
    }
}
