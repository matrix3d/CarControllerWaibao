using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public static GameMgr Instance;
    public Transform startPos;
    public Transform endPos;
    public GameObject carprefab;
    public GameObject gameui;
    public GameObject gameOverui;
    public float startTime;
    public GameObject car;
    public bool playing;

    public Button quitbtn;
    private void Awake()
    {
        Instance = this;
        gameui.SetActive(false);

        quitbtn.onClick.AddListener(() => {
            Application.Quit();
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartGame()
    {
        playing = true;
        startTime = Time.time;
        if (car!=null)
        {
            Destroy(car);
        }
        car= Instantiate(carprefab,startPos.position,Quaternion.identity);
        var cf = Camera.main.GetComponent<CameraFollow>();
        cf.target = car.transform;
        cf.enabled = true;
        cf.fly();
        gameui.SetActive(true);
        gameui.GetComponent<GameUI>().StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        playing = false;
        var fintime=Time.time-startTime;
        gameOverui.GetComponent<GameOverUI>().udpateUI(fintime);
        gameOverui.SetActive(true);
        var f= PlayerPrefs.GetFloat("a", 99999999);
        if (fintime < f)
            PlayerPrefs.SetFloat("a", fintime);

    }
}
