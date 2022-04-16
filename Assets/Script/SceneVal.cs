using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneVal : MonoBehaviour
{
    public static SceneVal ins;
    private void Awake() 
    {
        if (ins == null){
            ins = this;
            DontDestroyOnLoad(this);
        }else
        {
            Destroy(gameObject);
        }
    }
    string sceneData = null;
    private void WriteSceneData(string data)
    {
        sceneData = data;
    }

    public string ReadSceneData()
    {
        string tempData = sceneData;
        sceneData = null;
        return tempData;
    }
    public void ToNewScene(string sceneName, string data = null)
    {
        this.WriteSceneData(data);

        SceneManager.LoadScene(sceneName);
    }
}