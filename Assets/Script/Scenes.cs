using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Scenes : MonoBehaviour
{
    public void Level1(GameObject ui)
    {
        ui.SetActive(true);
        //todo 顯示載入條
        Invoke("GameStart",3);
    }
        public void Options()
    {
        SceneManager.LoadScene("Options");
    }
        public void GoBack()
    {
        SceneManager.LoadScene("FrontPage");
    }
        public void Exit()
    {
        Application.Quit();
    }
    public void GameStart()
    {
        SceneManager.LoadScene("NewLevel01");
    }
}
