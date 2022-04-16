using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandom : MonoBehaviour
{
//    public GameObject prefab;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log((int)Random.Range(0f, 10.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            int Intimidate = Random.Range(1,3);

            Debug.Log("Intimidate:"+ Intimidate);
            
            animator.SetInteger("Intimiadte",Intimidate);
            //Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f),0,Random.Range(-10.0f,10.0f));
            //Instantiate(prefab, position, Quaternion.identity);
        
        } 
    }
}
