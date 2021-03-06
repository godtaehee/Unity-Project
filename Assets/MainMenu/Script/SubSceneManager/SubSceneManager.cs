using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SubSceneManager : MonoBehaviour
{
    
    public static SubSceneManager instance = null; 

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    GameObject[] StarList = new GameObject[42];
    GameObject[] KoreanList = new GameObject[14];
    Button[] Btn = new Button[14];

    Canvas isCanvas;

    static public int StageNumber;
    static public int Star;
    [HideInInspector]
    public bool gameover = false;
   
    // Start is called before the first 0o8ilkhg. ,frame update

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        KoreanList = GameObject.FindGameObjectsWithTag("Button");
        StarList = GameObject.FindGameObjectsWithTag("Star");
        isCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        for (int i = 0; i < 14; i++)
        {
            Btn[i] = KoreanList[i].GetComponent<Button>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
        AppearStar();
        AppearButton();
    }

    void CheckGameOver()
    {
        if (gameover == true)
        {
            isCanvas.enabled = true;
            gameover = false;

            Star++;

            PlayerPrefs.SetInt("Star", Star);
            PlayerPrefs.Save();

            if (Star == 3)
            {
                StageNumber++;
                Star = 0;
            }

        }
    }

    void AppearStar()
    {
        for (int i = 0; i < 3 * StageNumber + Star; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                StarList[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    void AppearButton()
    {
        for (int i = 0; i < 14; i++)
        {
            if (i <= StageNumber)
            {
                Btn[i].interactable = true;
            }
        }
    }

    void InitGame()
    {

    }

    public void LGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LSubMenu()
    {
            SceneManager.LoadScene(0);
    }

    public void LMainMenu()
    {
        isCanvas.enabled = false;
        SceneManager.LoadScene(0);
        
    }

}
