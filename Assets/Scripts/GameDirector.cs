using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    float time = 60;
    public GameObject cat;
    public Text GameOverText;
    private bool gameOver = false;
    public GameObject replaybutton11;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.cat = GameObject.Find("Cat");
        this.replaybutton11 = GameObject.Find("ReplayButton11");
        replaybutton11.SetActive(false);
    }

    void Update()
    {
        Timer(); //時間に関する処理
        GameOver(); //ステージから落ちた時の処理
    }

    void Timer()
    {
        this.time -= Time.deltaTime;

        if (time < 0)
        {
            time = 0;
            GameOverText.enabled = true;
            replaybutton11.SetActive(true);
            cat.SetActive(false);
        }

        //右上に制限時間表示
        this.timerText.GetComponent<Text>().text =
            this.time.ToString("F0");
    }

    void GameOver()
    {
        if(cat.transform.position.y < -10.0f)
        {
            gameOver = true;

            if(gameOver)
            {
                GameOverText.enabled = true;
                replaybutton11.SetActive(true);
                timerText.SetActive(false);
            }
        }
    }
}
