using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text timeLb;
    public Text distanceLb;

    private void Start()
    {
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameMgr.Instance.playing)
        {
            return;
        }
        var time = (int)(Time.time - GameMgr.Instance.startTime);
        int minutes = time / 60;
        int seconds = time % 60;
        timeLb.text ="用时 "+ minutes + ":" + seconds;

        distanceLb.text = "距离终点 " + (int)((GameMgr.Instance.endPos.position - GameMgr.Instance.car.transform.position).magnitude) + "米";
    }
}
