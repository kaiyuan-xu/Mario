using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starts : MonoBehaviour
{
    public GameObject Play;
    public GameObject PlayPro;

    public Transform t1;
    public Transform t2;
    // Start is called before the first frame update
    void Start()
    {   if (ScenceLoader.Pa == false)
        {
            Chan();
        }
        if (ScenceLoader.Pa == true)
        {
            ChanN(); 
            //Invoke("Chan", 0.5f);
            ScenceLoader.Pa = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Chan()
    {
        if (PlayerControl.HP == 1)
        { Instantiate(Play, t1.position, Quaternion.identity); }
        if (PlayerControl.HP == 2)
        { Instantiate(PlayPro, t1.position, Quaternion.identity); }
    }
    private void ChanN()
    {
        if (PlayerControl.HP == 1)
        { Instantiate(Play, t2.position, Quaternion.identity); }
        if (PlayerControl.HP == 2)
        { Instantiate(PlayPro, t2.position, Quaternion.identity); }
    }
}
