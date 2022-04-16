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
            sickleAnime.SetBool("Attack", true);
            sickleAnime.SetInteger("AttackType", 1);
        } else {
            swordPanel.SetActive(false);
            swordAnime.SetBool("Attack", true);
            sickleAnime.SetInteger("AttackType", 0);
        }
    }

    public void PointerExit(int id)
    {
        if (id == 1) {
            sicklePanel.SetActive(true);
            sickleAnime.SetBool("Attack", false);
        } else {
            swordPanel.SetActive(true);
            swordAnime.SetBool("Attack", false);
        }
    }

    public void PointerClick(int id)
    {

    }
}
