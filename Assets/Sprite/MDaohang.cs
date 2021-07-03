using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MDaohang : MonoBehaviour
{
    public AFindPath path;
    Vector2[] pos;
    private int index = 0;
    private Animator ani;
    public bool isGround = true;
    public bool swim = false;
    // Use this for initialization
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLookMouse();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            //寻找路径，返回路径结点
            pos = path.FindingPath(transform.position, hit.point);
            index = 0;

            //if(isGround==true&&swim==false)
            //{
                ani.SetBool("run", true);
                ani.SetBool("isGround", true);
            //}
            //if(isGround==false&&swim==true)
            //{
            //    ani.SetBool("swim", true);
            //    ani.SetBool("swims", false);
            //    ani.SetBool("isGround", false);
            //}
        }
        if (pos != null && index < pos.Length)
        {
            //拿到下个点
            Vector2 v = pos[index];
            //目前的点到下个点的方向向量
            Vector2 dir = v - new Vector2(transform.position.x, transform.position.y);
            transform.Translate(dir.normalized * 1f * Time.deltaTime);

            //if (isGround == true && swim == false)
            //{
                ani.SetBool("run", true);
                ani.SetBool("isGround", true);
            //}
            //if (isGround == false && swim == true)
            //{
            //    ani.SetBool("swim", true);
            //    ani.SetBool("swims", false);
            //    ani.SetBool("isGround", false);
            //}
            //如果到达这个点
            if (Vector2.Distance(transform.position, v) < 0.1f)
            {
                index++;
                //if (isGround == true && swim == false)
                //{
                    ani.SetBool("run", false);
                    ani.SetBool("isGround", true);
                //}
                //if (isGround == false && swim == true)
                //{
                //    ani.SetBool("swims", true);
                //    ani.SetBool("isGround", false);
                //}
            }
        }
    }
    void PlayerLookMouse()
    {
        //获取鼠标坐标
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 localMousePosition = transform.InverseTransformPoint(worldMousePosition);

        //通过鼠标坐标改变动画方向
        ani.SetFloat("MousePositionX", localMousePosition.x);
        ani.SetFloat("MousePositionY", localMousePosition.y);
    }
}
