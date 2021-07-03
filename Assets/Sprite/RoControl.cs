using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoControl : MonoBehaviour
{
    private Rigidbody2D rBody;
    private int dir = -1;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.AddForce(Vector2.up * 50f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 0.4f * dir * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dir = -dir;
        if (collision.collider.tag == "Player")
        {
            ScenceLoader.score += 100;
            collision.collider.GetComponent<PlayerControl>().Pro();
            Destroy(gameObject);
        }
        if(collision.collider.tag=="PlayerPro")
        {
            ScenceLoader.score += 100;
            Destroy(gameObject);
        }
    }
}
