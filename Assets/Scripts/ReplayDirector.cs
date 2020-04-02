using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayDirector : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void ReplayButton1Clicked()
    {
        SceneManager.LoadScene("MainScene"); //最初の画面に戻る
    }

    public void ReplayButton2Clicked()
    {
        SceneManager.LoadScene("MainScene"); //最初の画面に戻る
    }
}
