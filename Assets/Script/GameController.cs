using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject image;
    public Text marquee;
    public string[] text;
    public string currentText;
    public int textSpeed;
    int currentTextCount = 0;
    float timer_f;
    int timer_i ;
    int current_timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTextCount <= text.Length - 1)
        {
            if (timer_i < text[currentTextCount].Length)
            {
                timer_f += Time.deltaTime * textSpeed;
                timer_i = (int)timer_f;
            }
        }

        AddText();
        buttonDown();
    }
    
    void AddText()
    {
        if (current_timer != timer_i)
        {
            currentText += text[currentTextCount][timer_i - 1];
            marquee.text = currentText;

            current_timer = timer_i;
        }
    }

    void buttonDown()
    {
        if (current_timer == text[currentTextCount].Length)
        {
            if(currentTextCount <= text.Length - 1)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log("KeyCode.Space");
                    timer_f = 0;
                    timer_i = 0;
                    current_timer = 0;
                    currentText = null;
                    if(currentTextCount <= text.Length - 1)
                    {
                        currentTextCount++;
                    }
                }
            }
        }
    }
}