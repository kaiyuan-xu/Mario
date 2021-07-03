using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wudi : MonoBehaviour
{
    //public GameObject WudiP;
    public GameObject SMa;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("WudiD", 0.1f);
        //WudiD();
        //System.Threading.Thread.Sleep(1500);
        PlayerControl.HP--;
        Invoke("Sma", 1.5f);
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void WudiD()
    //{
    //    
    //    Instantiate(WudiP, transform.position, Quaternion.identity);
    //}
    public void Sma()
    {
        Instantiate(SMa, transform.position, Quaternion.identity);
    }
}
