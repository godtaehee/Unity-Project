using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{

    public GameObject PauseMenu;
    Canvas isCanvas;
    // Start is called before the first frame update
    void Start()
    {
        isCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        PauseMenu = GameObject.Find("PauseMenu");
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseButton()
    {
        if (Time.timeScale == 0.0f)
        { 
            Time.timeScale = 1.0f;
            PauseMenu.SetActive(false);
        }
            
        else
        { 
            Time.timeScale = 0.0f;
            PauseMenu.SetActive(true);
        }
            
    }

    public void RestartButton()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
    }

    public void ExitButton()
    {
        isCanvas.enabled = true;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }


}

