using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboComtroller : MonoBehaviour
{
    public static ComboComtroller _instance;
    public Text comboText;
    public float comboTime = 2;
    private int comboCount = 0;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            this.gameObject.SetActive(false);
            comboCount = 0;
        }
    }

    public void combostart()
    {
        this.gameObject.SetActive(true);
        timer = comboTime;
        comboCount++;
        string color = "yellow";
        int size = 20;
        if (comboCount > 10)
        {
            color = "red";
            size = 50;
        }

        string style = "<color=" + color + "><size=" + size +">";
        comboText.text = "連擊x" + style + comboCount + "</size></color>";

        LeanTween.scale(gameObject, Vector3.zero, 1f).setEase(LeanTweenType.punch);
    }
}
