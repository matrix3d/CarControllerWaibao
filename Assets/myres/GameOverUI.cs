using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Button btn;
    public Text timelb;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() => {
            gameObject.SetActive(false);
            GameMgr.Instance.MainUI();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void udpateUI(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        timelb.text = "”√ ± " + minutes + ":" + seconds;
    }
}
