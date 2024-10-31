using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public static GameMgr Instance;
    Transform startPos;
    public Transform endPos;
    public GameObject carprefab;
    public GameObject[] lvsprefab;
    public GameObject gameui;
    public GameObject gameOverui;
    public GameObject startGameui;
    public GameObject mainui;
    public GameObject maincene;
    public float startTime;
    public GameObject car;
    public GameObject lv;
    public bool playing;

    public Button quitbtn;
    public float score;
    Vector3 lastCarPos;
    private void Awake()
    {
        Instance = this;
        startGameui.SetActive(true);
        gameui.SetActive(false);
        mainui.SetActive(false);
        quitbtn.gameObject.SetActive(false);

        quitbtn.onClick.AddListener(() => {
            Application.Quit();
        });
        score = PlayerPrefs.GetFloat("b2", 0);
    }

    public void addScore(float v)
    {
        score += v;
        PlayerPrefs.SetFloat("b2", score);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartGame(int i)
    {
        playing = true;
        maincene.SetActive(false);
        startTime = Time.time;
        if (lv != null)
        {
            Destroy(lv);
        }
        lv = Instantiate(lvsprefab[i]);//, startPos.position, Quaternion.identity);
        startPos = lv.transform.Find("startPos");
        endPos = lv.transform.Find("endPos");
        if (car!=null)
        {
            Destroy(car);
        }
        car= Instantiate(carprefab,startPos.position,startPos.rotation);
        lastCarPos = car.transform.position;
        var cf = Camera.main.GetComponent<CameraFollow>();
        cf.target = car.transform;
        cf.enabled = true;
        cf.fly();
        gameui.SetActive(true);

        quitbtn.gameObject.SetActive(true);
        gameui.GetComponent<GameUI>().StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (playing)
        {
            var nowp = car.transform.position;
            var d = (nowp- lastCarPos).magnitude;
            addScore(d);
            lastCarPos = nowp;
        }
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

    internal void MainUI()
    {
        if (lv != null)
        {
            Destroy(lv);
        }
        if (car != null)
        {
            Destroy(car);
        }
        mainui.SetActive(true);
        gameui.SetActive(false);
        maincene.SetActive(true);
    }
}
