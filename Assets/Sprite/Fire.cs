using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public static bool Rota = false;
    private float speed = 0.8f;
    private bool S = false;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SS();
        Die();
    }

    private void SS()
    {
        if (Rota == false) { S = false; }
        else if (Rota == true) { S = true; }
    }

    // Update is called once per frame
    void Update()
    {
        Li();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { collision.GetComponent<PlayerControl>().Die(); }
        if (collision.tag == "PlayerPro")
        { collision.GetComponent<PlayerPro>().Die(); }
    }
    private void Die()
    {
        Destroy(gameObject, 12f);
    }
    private void Li()
    {
        if (S==false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            sr.flipX = false;
        } 
        else if(S==true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            sr.flipX = true;
        }
    }
    
}
