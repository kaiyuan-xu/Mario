using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScenceLoader.score += 100;
        //获得刚体
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150f);
        //销毁金币
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
