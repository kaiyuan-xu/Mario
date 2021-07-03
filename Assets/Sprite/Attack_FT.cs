using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_FT : MonoBehaviour
{
    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        Li();
        Die();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { collision.GetComponent<PlayerControl>().Die();}
        if (collision.tag == "PlayerPro")
        { collision.GetComponent<PlayerPro>().Die(); }
    }

    private void Die()
    { Destroy(gameObject,1f);}

    private void Li()
    { GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150f); }
}
