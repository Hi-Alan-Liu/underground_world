using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour

{
    // Start is called before the first frame update
    public GameObject destroyNoise;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Attack")
        {
            Debug.Log("撞門");
            Invoke("Destroy", 5);
        }
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
    void Noise()
    {
        GameObject gameObject = destroyNoise;
        Instantiate(gameObject, new Vector3(transform.position.x,transform.position.y+2f,transform.position.z),transform.rotation);
    }
}
