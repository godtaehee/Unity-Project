using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    GameObject player; // 플레이어
    RJoyStick joybutton; // 오른쪽 조이스틱
    public GameObject Apear;
    public GameObject[] ChildApear;
    public GameObject Card;
    public GameObject Good;
    public GameObject Bad;

    public AudioClip CorrectAudio;
    public AudioClip WrongAudio;
    AudioSource Audio;
 

    bool correct;

    public bool isPlayerEnter; //아이템이 플레이어하고 부딪혔는지


    // Use this for initialization
    void Start()
    {

        Good = GameObject.Find("Good");
        Bad = GameObject.Find("Bad");
        Apear = GameObject.Find("Appear");
        player = GameObject.FindGameObjectWithTag("Player"); // 플레이어 태그로 플레이어객체를 찾음
        Card = GameObject.Find(this.transform.gameObject.name);
        Audio = GetComponent<AudioSource>();
        joybutton = FindObjectOfType<RJoyStick>();
        ChildApear = new GameObject[28];
        Good.GetComponent<RawImage>().enabled = false;
        Bad.GetComponent<RawImage>().enabled = false;

        for (int i = 0; i < 28; i++)
        {
            ChildApear[i] = Apear.transform.GetChild(i).gameObject;
            ChildApear[i].GetComponent<RawImage>().enabled = false;
        }

        for (int i = 0; i < 28; i++)
        {
            if (ChildApear[i].name == this.transform.gameObject.name)
            {
                Card = ChildApear[i];

            }

        }


    }

    // Update is called once per frame
    void Update()
    {

        Wrong();
        Correct();
        
    }

    void Correct()
    {
        if (isPlayerEnter && joybutton.Pressed)
        {
            
            Card.GetComponent<RawImage>().enabled = true;
            
            Invoke("AllOff", 2);

            if (transform.tag == "Correct")
                
            {
                Goodsetting();
                Audio.clip = CorrectAudio;
                Audio.Play();
                Invoke("MakeAlready", 1);
                
                
            }


        }
    }

    void Wrong()
    {
        if (isPlayerEnter && joybutton.Pressed)
        {

            Card.GetComponent<RawImage>().enabled = true;

            Invoke("AllOff", 2);

            if (transform.tag == "Already" || transform.tag == "Basic")
            {
                Audio.clip = WrongAudio;
                Audio.Play();

                Failsetting();

            }
        }
    }

    void MakeAlready()
    {
        transform.tag = "Already";
    }


    void Goodsetting()
    {
        Good.GetComponent<RawImage>().enabled = true;
    }

    void Failsetting()
    {
        Bad.GetComponent<RawImage>().enabled = true;
    }

    void AllOff()
    {
        Bad.GetComponent<RawImage>().enabled = false;
        Good.GetComponent<RawImage>().enabled = false;
        Card.GetComponent<RawImage>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {

            if (collision.gameObject == player)
            {
                isPlayerEnter = false;
            }
    }
}