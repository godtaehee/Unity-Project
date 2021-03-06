using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectDuplicate : MonoBehaviour
{
    public static ProtectDuplicate instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    void InitGame()
    {

    }

}
