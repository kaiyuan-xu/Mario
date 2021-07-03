using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform targets;//获取马里奥的位置
    private Transform Target;
    public float minX;//限制摄像机移动范围
    public float maxX;
    private bool A = false;
    private bool B = true;
    // Start is called before the first frame update
    void Start()
    {
        //Position();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;//因为角色要跳跃，所以应该只改变X轴
        //if(!A)
        //{
        //    Position();
        //    A = true;
        //}

        if(PlayerControl.HP==1)
        {
            if (!A)
            {
                Position();
                B = true;
                A = true;
                //Debug.Log(PlayerControl.HP);
            }
            //Debug.Log(PlayerControl.HP);
            pos.x = targets.position.x;
        }
        else if (PlayerControl.HP==2)
        {
            if (B)
            {
                Position();
                A = false;
                B = false;
                //Debug.Log(PlayerControl.HP);
            }
            //Debug.Log(PlayerControl.HP);
            pos.x = Target.position.x;
        }

        if (pos.x < minX)
        {
            pos.x = minX;
        }
        if (pos.x > maxX)
        {
            pos.x = maxX;
        }
        //再赋值回去
        transform.position = pos;
    }
    public void Position()
    {
        if (PlayerControl.HP == 1)
        {
            //Debug.Log(PlayerControl.HP);
            targets = GameObject.FindWithTag("Player").transform;
        }
        if (PlayerControl.HP == 2)
        {
            //Debug.Log(PlayerControl.HP);
            Target = GameObject.FindWithTag("PlayerPro").transform;
        }
    }
}