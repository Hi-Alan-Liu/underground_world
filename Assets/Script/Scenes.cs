using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Scenes : MonoBehaviour
{
    public GameObject option;
    public GameObject selectPlayer;
    public GameObject loading;
    public Transform progeressBar;
    float time= 0 ;
    bool is_loading = false;
    public void Update()
    {
        ProgeressBar();

        if(is_loading)
        {
            time += Time.deltaTime;
        }
    }

    public void SelectPlayer()
    {
        option.SetActive(false);
        selectPlayer.SetActive(true);
    }

    public void Loading (int player_code)
    {
        selectPlayer.SetActive(false);
        loading.SetActive(true);
        is_loading = true;
        Invoke("GameStart",3);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Back()
    {
        option.SetActive(true);
        selectPlayer.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("NewLevel01");
    }

    public void ProgeressBar()
    {
        progeressBar.localPosition = new Vector3(-1280 + ((1280/ 3)* time), -460f,0f);
    }
}
