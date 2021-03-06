using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    GameObject Heart;
    GameObject body; // 무적상태시 색깔변환을위한 플레이어의 바디
    Canvas isCanvas;
    Animator ani;

    Rigidbody Rigid;
    SkinnedMeshRenderer skin; // body에 붙혀있는 SkinnedMeshRenderer

    RJoyStick joybuttons; // 오른쪽 조이스틱

    int maxHealth = 3; // 최대생명력
    int health = 3; // 현재생명력

    bool isDie; // 현재생명력이 0 이되면 True가 됨
   public bool isWrong; // 잘못된 아이템을 주웠는지
    public bool isUnBeatTime = false; // 무적상태




    // Use this for initialization
    void Start()
    {
        Heart = GameObject.Find("Heart");
        body = GameObject.Find("Haruko_body"); // 플레이어의 색체부분
        isCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        ani = GetComponent<Animator>();
        skin = body.GetComponent<SkinnedMeshRenderer>(); // 대입
        joybuttons = FindObjectOfType<RJoyStick>();
        Rigid = gameObject.GetComponent<Rigidbody>();

        health = maxHealth; // 최대생명력으로 현재생명력을 맞춤
    }


    void Update()
    {
        
        CheckGameOver();
        PickWrong();
        LifeState();
    }
    

    IEnumerator UnBeatTime()
    {
        int countTime = 0;

        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                skin.material.color = new Color32(255, 255, 255, 90);
            else
                skin.material.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.01f);

            countTime++;
        }

        skin.material.color = new Color32(255, 255, 255, 255);

        isUnBeatTime = false;

        yield return null;
    }

    void CheckGameOver()
    {
        // 현재생명력이 0 이면 게임끝
        if (health == 0)
        {
            if (!isDie)
            {
                Die();
                
                ani.Play("jump");
                Invoke("MoveScene", 4);
            }
                
            return;
        }
    }

    void MoveScene()
    {
        SceneManager.LoadScene(0);
        isCanvas.enabled = true;
    }

    void PickWrong()
    {
        if (isWrong && joybuttons.Pressed && !isUnBeatTime)
        {
            
            health--;
            isUnBeatTime = true;

            if (health >= 1)
            {
                isUnBeatTime = true;
                StartCoroutine("UnBeatTime");
            }

        }
    }

    void LifeState()
    {
        if (health < 3)
        {
            Heart.transform.GetChild(health).gameObject.SetActive(false);
        }
    }

    void Die()
    {
        isDie = true;

        Rigid.velocity = Vector3.zero;

        /*BoxCollider[] colls = gameObject.GetComponents<BoxCollider>();
        colls[0].enabled = false;
        colls[1].enabled = false;*/
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basic" || other.gameObject.tag == "Already")
        {
            Debug.Log("dfsdf");
            isWrong = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isWrong = false;
    }

}