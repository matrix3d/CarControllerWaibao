using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    public Button startBtn;
    public Text timelb;
    // Start is called before the first frame update
    void Start()
    {
        var time = PlayerPrefs.GetFloat("a", -1);
        if (time > 0)
        {
            int minutes = (int)time / 60;
            int seconds = (int)time % 60;
            timelb.text = "最好成绩 " + minutes + ":" + seconds;
        }
        else
        {
            timelb.text = "最好成绩 无";
        }

        startBtn.onClick.AddListener(() => { 
            gameObject.SetActive(false);
            GameMgr.Instance.StartGame();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
