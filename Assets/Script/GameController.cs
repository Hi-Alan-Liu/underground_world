using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject panel;
    public Text panelText;
    public string[] text;
    public float textspeed;
    public int currentTextcount = 0;
    bool textFinished = true;

    public bool gameFinish = false;
    public GameObject finishPanel;
    public Text finishTime;
    public Text finishScore;
    public int score = 0;


    // void Awake()
    // {
    //     if (SceneVal.ins.ReadSceneData() != null)
    //     {
    //         string data = SceneVal.ins.ReadSceneData();
    //         Debug.Log(data);
    //     }
    // }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && textFinished == true)
        {
            if (currentTextcount == text.Length)
            {
                panel.SetActive(false);
                currentTextcount = 0;
                return;
            }
            StartCoroutine(SetTextUI());
        }

        if(Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("FrontPage");
            }
        if (gameFinish)
        {
            finishPanel.SetActive(true);
            finishTime.text = "遊戲時間:" + Mathf.Round(Time.time) + "秒";
            finishScore.text = "遊戲分數:" + score;
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        panelText.text = "";

        for (int i = 0; i < text[currentTextcount].Length; i++)
        {
            panelText.text += text[currentTextcount][i];

            yield return new WaitForSeconds(textspeed);
        }

        textFinished = true;
        currentTextcount++;
    }
}