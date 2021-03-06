using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{

    // 초성, 중성, 종성 테이블.
    private static string Initial_array = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
    private static string medial_array = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
    private static string final_array = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
    private static ushort Base = 0xAC00;
    private static ushort Last = 0xD79F;
    private static string Initial;
    private static string medial;
    private static string final;


    public GameObject RightItem;
    public GameObject Target; // 정답인애들
    public GameObject SlotTarget;
    public GameObject CorrectSlot;
    public GameObject Character;

    GameObject First;
    GameObject Second;
    GameObject Third;
    GameObject Array_Color;

    List<GameObject> RightSlot = new List<GameObject>();

    GameObject[] Array_RightItem; 
    GameObject[] Array_Colors;


    Canvas isCanvas;
    public GameObject Wins;
    
    static public SubSceneManager isScene;

    string Problem = "바나고";

    int size;
    int count = 0;
    int select;

    // Start is called before the first frame update
    void Start()
    {
        First = GameObject.Find("Bundle1");
        Second = GameObject.Find("Bundle2");
        Third = GameObject.Find("Bundle3");
        Wins = GameObject.Find("Win");
        Target = GameObject.Find("Correct");
        isScene = GameObject.Find("Scene").GetComponent<SubSceneManager>();
        isCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        isCanvas.enabled = false;
        Array_RightItem = new GameObject[28];
        Wins.gameObject.SetActive(false);

        if (Problem.Length == 2)
        {
            RightSlot.Add(Third);
            RightSlot.Add(Second);
            
        }
        else
        {
            RightSlot.Add(First);
            RightSlot.Add(Second);
            RightSlot.Add(Third);
        }


        for (int i = 0; i < RightSlot.Count; i++)
        {

            RightSlot[i].gameObject.SetActive(false);

            for (int j = 0; j < 4; j++)
                RightSlot[i].transform.GetChild(j).gameObject.SetActive(false);

        }

        for (int i = 0; i < 28; i++)
        {
            Array_RightItem[i] = SlotTarget.transform.GetChild(i).gameObject;
        }


        
        

    }

    // Update is called once per frame
    void Update()
    {

        int length = Problem.Length; // String의 길이

        while (count < length)
        {

            Divide(Problem);
            RightFunction(Problem, select);

        }
        
        GameManager();
        
    }

    void RightFunction(string a, int b)
    {

        RightSlot[count - 1].gameObject.SetActive(true);

        for (int j = 0; j < 4; j++)
        {
            if (RightSlot[count - 1].transform.GetChild(j).gameObject.activeSelf == false)
            {
                RightSlot[count - 1].transform.GetChild(select).gameObject.SetActive(true);
            }
        }


        if (select == 0) // 강
        {

            for (int z = 0; z < CorrectSlot.transform.childCount; z++)
            {
                if (CorrectSlot.transform.GetChild(z).name == "Slot" + Initial)
                    RightSlot[count - 1].transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture = CorrectSlot.transform.GetChild(z).GetComponent<RawImage>().texture;

                else if (CorrectSlot.transform.GetChild(z).name == "Slot" + medial)
                    RightSlot[count - 1].transform.GetChild(0).transform.GetChild(1).GetComponent<RawImage>().texture = CorrectSlot.transform.GetChild(z).GetComponent<RawImage>().texture;

                else if (CorrectSlot.transform.GetChild(z).name == "Slot" + final)
                    RightSlot[count - 1].transform.GetChild(0).transform.GetChild(2).GetComponent<RawImage>().texture = CorrectSlot.transform.GetChild(z).GetComponent<RawImage>().texture;

            }

            for (int i = 0; i < 3; i++)
            {
                RightSlot[count - 1].transform.GetChild(0).transform.GetChild(i).tag = "CorrectSlot";
            }



        }
        else if (select == 1) // 공 
        {

            for (int z = 0; z < CorrectSlot.transform.childCount; z++)
            {
                if (CorrectSlot.transform.GetChild(z).name == "Slot" + Initial)
                {
                    RightSlot[count - 1].transform.GetChild(1).transform.GetChild(0).GetComponent<RawImage>().texture = CorrectSlot.transform.GetChild(z).GetComponent<RawImage>().texture;
                }

                else if (CorrectSlot.transform.GetChild(z).name == "Slot" + medial)
                {
                    RightSlot[count - 1].transform.GetChild(1).transform.GetChild(1).GetComponent<RawImage>().texture = CorrectSlot.transform.GetChild(z).GetComponent<RawImage>().texture;
                }

                else if (CorrectSlot.transform.GetChild(z).name == "Slot" + final)
                {
                    RightSlot[count - 1].transform.GetChild(1).transform.GetChild(2).GetComponent<RawImage>().texture = CorrectSlot.transform.GetChild(z).GetComponent<RawImage>().texture;
                }

            }

            for (int i = 0; i < 3; i++)
            {
                RightSlot[count - 1].transform.GetChild(1).transform.GetChild(i).tag = "CorrectSlot";
            }


        }
        else if (select == 2) // 가
        {

            for (int z = 0; z < CorrectSlot.transform.childCount; z++)
            {
                if (CorrectSlot.transform.GetChild(z).name == "Slot" + Initial)
                {
                    RightSlot[count - 1].transform.GetChild(2).transform.GetChild(0).GetComponent<RawImage>().texture = CorrectSlot.transform.GetChild(z).GetComponent<RawImage>().texture;
                    RightSlot[count - 1].transform.GetChild(2).transform.GetChild(0).name = "Right" + Initial;
                }

                else if (CorrectSlot.transform.GetChild(z).name == "Slot" + medial)
                {
                    RightSlot[count - 1].transform.GetChild(2).transform.GetChild(1).name = "Right" + medial;
                    RightSlot[count - 1].transform.GetChild(2).transform.GetChild(1).GetComponent<RawImage>().texture = CorrectSlot.transform.GetChild(z).GetComponent<RawImage>().texture;
                }

            }

            for (int i = 0; i < 2; i++)
            {
                RightSlot[count - 1].transform.GetChild(2).transform.GetChild(i).tag = "CorrectSlot";
            }

        }
        else if (select == 3) // 고
        {


            for (int z = 0; z < CorrectSlot.transform.childCount; z++)
            {
                if (CorrectSlot.transform.GetChild(z).name == "Slot" + Initial)
                {
                    RightSlot[count - 1].transform.GetChild(3).transform.GetChild(0).name = "Right" + Initial;
                    RightSlot[count - 1].transform.GetChild(3).transform.GetChild(0).GetComponent<RawImage>().texture = CorrectSlot.transform.GetChild(z).GetComponent<RawImage>().texture;
                }

                else if (CorrectSlot.transform.GetChild(z).name == "Slot" + medial)
                {
                    RightSlot[count - 1].transform.GetChild(3).transform.GetChild(1).name = "Right" + medial;
                    RightSlot[count - 1].transform.GetChild(3).transform.GetChild(1).GetComponent<RawImage>().texture = CorrectSlot.transform.GetChild(z).GetComponent<RawImage>().texture;
                }

            }

            for (int i = 0; i < 2; i++)
            {
                RightSlot[count - 1].transform.GetChild(3).transform.GetChild(i).tag = "CorrectSlot";
            }


        }
    
    }




    public void Divide(string a)
    {
        
        
        int initial_location, medial_location, final_location; // 초성,중성,종성의 인덱스

        GameObject _initial, _medial, _final;
        GameObject Slot_initial, Slot_medial, Slot_final;

        ushort uTempCode = 0x0000;       // 임시 코드용
        uTempCode = Convert.ToUInt16(a[count]); //Char을 16비트 부호없는 정수형 형태로 변환 - Unicode


        // 캐릭터가 한글이 아닐 경우 처리
        if ((uTempCode < Base) || (uTempCode > Last))
        {
            Initial = ""; medial = ""; final = "";
        }

        // iUniCode에 한글코드에 대한 유니코드 위치를 담고 이를 이용해 인덱스 계산.
        int iUniCode = uTempCode - Base;

        initial_location = iUniCode / (21 * 28);
        iUniCode = iUniCode % (21 * 28);

        medial_location = iUniCode / 28;
        iUniCode = iUniCode % 28;

        final_location = iUniCode;


        // 분리된 자음 모음들을 String 변수에 담는과정
        Initial = new string(Initial_array[initial_location], 1);
        medial = new string(medial_array[medial_location], 1);
        final = new string(final_array[final_location], 1);


        //글자에 맞는 객체를 찾는과정
        _initial = GameObject.Find(Initial);
        _medial = GameObject.Find(medial);

        Slot_initial = GameObject.Find("Slot" + Initial);
        Slot_medial = GameObject.Find("Slot" + medial);



        if (final != " ")
        {
           _final = GameObject.Find(final);
            _final.transform.SetParent(Target.transform);
            Slot_final = GameObject.Find("Slot" + final);
            Slot_final.transform.SetParent(CorrectSlot.transform);

            Debug.Log("받침있는숫자 ::   " + medial_location);

            if (medial_location < 8 || medial_location == 20)
            {
                select = 0;
            }
            else
                select = 1;
 
        }

        else
        {
            if (medial_location < 8 || medial_location == 20)
            {
                select = 2;
            }
            else
                select = 3;

        }


        //Correct의 자식으로 들어갑니다.
        _initial.transform.SetParent(Target.transform);
        _medial.transform.SetParent(Target.transform);
        Slot_initial.transform.SetParent(CorrectSlot.transform);
        Slot_medial.transform.SetParent(CorrectSlot.transform);


        //정답의 개수
        int size = Target.transform.childCount;
       
        //정답들을 배열에 넣고 한번에 태그를 Correct로 변경
        for (int i = 0; i < size; i++)
        {
            Target.transform.GetChild(i).tag = "Correct";
            
        }

        count++;

    }



    void GameManager()
    {
        int size = Target.transform.childCount;
        int gcount = 0;

        for (int i = 0; i < size; i++)
        {

            if (Target.transform.GetChild(i).tag == "Already")
            {
                
                    Array_Colors = GameObject.FindGameObjectsWithTag("CorrectSlot");

                for(int j = 0; j < Array_Colors.Length; j++)
                {
                    if (Array_Colors[j].name == "Right" + Target.transform.GetChild(i).name)
                        Array_Colors[j].GetComponent<RawImage>().color = Color.red;
                }
               
                gcount++;
            }

        }
        
        
        if (gcount == size)
        {
           // Character.GetComponent<Animation>().Play("Jump");
            Debug.Log("게임승리");
            
            Wins.gameObject.SetActive(true);
            Invoke("GameScene", 4);
        }

    }

    void GameScene()
    {
        isScene.gameover = true;
        isScene.LSubMenu();
    }








}

