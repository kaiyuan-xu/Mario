using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bron4 : MonoBehaviour
{
    public GameObject Play;
    public GameObject PlayPro;
    // Start is called before the first frame update
    void Start()
    {
        Creat1();
        ScenceLoader.isWorld1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Creat1()
    {
        if (PlayerControl.HP == 1)
        { Instantiate(Play, transform.position, Quaternion.identity); }
        if (PlayerControl.HP == 2)
        { Instantiate(PlayPro, transform.position, Quaternion.identity); }
    }
}
