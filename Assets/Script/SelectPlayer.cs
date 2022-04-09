using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public GameObject panel_1;

    public GameObject panel_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter(int id)
    {
        if (id == 1) {
            panel_1.SetActive(false);
        } else {
            panel_2.SetActive(false);
        }
    }

    public void PointerExit(int id)
    {
        if (id == 1) {
            panel_1.SetActive(true);
        } else {
            panel_2.SetActive(true);
        }
    }

    public void PointerClick(int id)
    {

    }
}
