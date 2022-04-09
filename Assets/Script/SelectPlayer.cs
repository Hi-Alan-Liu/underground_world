using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public GameObject sicklePanel;

    public GameObject swordPanel;

    public Animator sickleAnime;

    public Animator swordAnime;

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
            sicklePanel.SetActive(false);
            sickleAnime.SetTrigger("Attack");
        } else {
            swordPanel.SetActive(false);
            swordAnime.SetTrigger("Attack");
        }
    }

    public void PointerExit(int id)
    {
        if (id == 1) {
            sicklePanel.SetActive(true);
        } else {
            swordPanel.SetActive(true);
        }
    }

    public void PointerClick(int id)
    {

    }
}
