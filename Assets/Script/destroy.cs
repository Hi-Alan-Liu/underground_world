using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float time = 3;
    // Update is called once per frame
    void Update()
    {
        Invoke("Destroy", time);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
