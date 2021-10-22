using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Level1()
    {
        SceneManager.LoadScene("NewLevel01");
    }
        public void Options()
    {
        SceneManager.LoadScene("Options");
    }
        public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
