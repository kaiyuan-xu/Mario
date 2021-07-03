using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldControl : MonoBehaviour
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
        if (collision.tag == "Player"||collision.tag=="PlayerPro")
        {
            ScenceLoader.score += 100;
            //播放声音
            //AudioManager.Instance.PlaySound("金币");
            //销毁自己
            Destroy(gameObject);
        }
    }
}
