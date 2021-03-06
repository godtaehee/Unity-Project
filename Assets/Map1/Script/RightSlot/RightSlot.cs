using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RightSlot : MonoBehaviour
{
    GameObject Finding;
    RawImage[] Appear;
    int Findsize;

    // Start is called before the first frame update
    void Start()
    {
        Finding = GameObject.Find("RightItem");
        Appear = new RawImage[28];
        Findsize = Finding.transform.GetChildCount();
        for(int i = 0; i < Findsize; i++)
        {
            Appear[i] = Finding.GetComponentInChildren<RawImage>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
