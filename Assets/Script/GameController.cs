using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    public Text panelText;
    public string[] text;
    public float textspeed;
    public int currentTextcount = 0;
    bool textFinished = true;

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