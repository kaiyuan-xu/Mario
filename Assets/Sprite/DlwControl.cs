using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlwControl : MonoBehaviour
{
    //private float MoveSpeed = 1;

    public GameObject Dlws;/*
    public Transform FirstP;
    public Transform LastP;
    public Vector2 target;*/
    // Start is called before the first frame update
    void Start()
    {
        //target = LastP.position;
    }

    // Update is called once per frame
    void Update()
    {/*
        Dlw.transform.position = Vector2.MoveTowards(Dlw.transform.position, target, MoveSpeed * Time.deltaTime);
        if (transform.position == LastP.position)
        {
            target = FirstP.position;
        }
        if (transform.position == FirstP.position)
        {
            target = LastP.position;
        }*/
        if (Dlw.HP == 1)
        {
            Dlws.transform.position = new Vector2((0.5f * Mathf.Sin(Time.time) + 23f), -3.55f);
        }
        else
            return;
    }
}
