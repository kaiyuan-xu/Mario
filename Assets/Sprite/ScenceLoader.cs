using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class ScenceLoader : MonoBehaviour
{
    private int choice = 1;
    private bool Deadic = false;
    //public int hp;

    private Transform Img_Choice;
    public Transform posOne;
    public Transform posTwo;
    public Animator animator;
    public Button btnA;
    public Button btnB;
    public Text Score;
    public Text HP;

    public static int score = 0;
    public static bool isWorld = false;
    public static bool Pa = false;
    public static bool Win = false;
    public static bool Pa1 = false;
    public static bool isWorld1 = false;

    public GameObject eventObj;
    public GameObject Pass;
    public GameObject Show;
    public GameObject isDefeatUI;
    public GameObject isWinUI;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(eventObj.gameObject);

        Img_Choice = GameObject.FindGameObjectWithTag("Finish").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            choice = 1;
            Img_Choice.position = posOne.position;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            choice = 2;
            Img_Choice.position = posTwo.position;
        }
        if (choice == 1 && Input.GetKeyDown(KeyCode.E))
        {
            Invoke("SS", 0.2f);
            StartCoroutine(LoadScence(1));
        }
        else if(choice == 2 && Input.GetKeyDown(KeyCode.E))
        {
            Invoke("SS", 0.2f);
            StartCoroutine(LoadScence(3));
        }
        if (Input.GetKeyDown(KeyCode.S) && isWorld == true)
        {
            //Pa = true;
            Invoke("SS", 0.2f);
            StartCoroutine(LoadScence(2));
            //Pass = false;
        }
        if(Pa==true&&Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("SS", 0.2f);
            StartCoroutine(LoadScence(1));
        }
        if(Pa1==true&&Input.GetKeyDown(KeyCode.D))
        {
            Invoke("SS", 0.2f);
            StartCoroutine(LoadScence(3));
        }
        if(Input.GetKeyDown(KeyCode.S)&&isWorld1==true)
        {
            Invoke("SS", 0.2f);
            StartCoroutine(LoadScence(4));
        }

        if (PlayerControl.HP<=0&&Deadic==false)
        {
            Invoke("Sss", 1.5f);
            if(Input.GetMouseButtonDown(0))
            {
                StartCoroutine(LoadScence(0));
                PlayerControl.HP = 1;
                Deadic = false;
            }
        }
        if(Win==true&&PlayerControl.HP>=1)
        {
            Invoke("ShWin", 1.5f);
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(LoadScence(0));
                PlayerControl.HP = 1;
                Win = false;
            }
        }
        Score.text = score.ToString();
    }
    IEnumerator LoadScence(int index)//使用协程等待过渡动画结束
    {
        animator.SetBool("Fidein", true);
        animator.SetBool("Fideout", false);
        yield return new WaitForSeconds(1);//等待1秒
        //使用异步加载方式，用AsynOperation来接收
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadedScence;
    }

    private void OnLoadedScence(AsyncOperation obj)
    {
        animator.SetBool("Fidein", false);
        animator.SetBool("Fideout", true);
    }
    private void SS()
    {
        Show.SetActive(false);
        Pass.SetActive(false);
        isDefeatUI.SetActive(false);
        isWinUI.SetActive(false);
    }
    private void Sss()
    {
        isDefeatUI.SetActive(true);
        //Deadic = true;
    }
    private void ShWin()
    {
        isWinUI.SetActive(true);
    }
}
