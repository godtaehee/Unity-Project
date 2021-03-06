using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource SoundPlayer;

    void Start()
    {
        SoundPlayer = GameObject.Find("SoundPlayer").GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    public void OnMouseDown()
    {
        SoundPlayer.Play();
    }
}
